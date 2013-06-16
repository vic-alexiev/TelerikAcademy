using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A Dual-Key Dictionary class. The original (thread-safe) implementation
/// can be found at:
/// http://www.fyslexicduck.com/2009/02/multi-key-generic-dictionary-class-for.html
/// </summary>
/// <typeparam name="TKey1">The type of the primary key.</typeparam>
/// <typeparam name="TKey2">The type of the sub-key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
public class DualKeyDictionary<TKey1, TKey2, TValue> : IEnumerable<KeyValuePair<TKey1, TValue>>
{
    #region Private Fields

    private readonly Dictionary<TKey1, TValue> baseDictionary = new Dictionary<TKey1, TValue>();
    private readonly Dictionary<TKey2, TKey1> subDictionary = new Dictionary<TKey2, TKey1>();
    private readonly Dictionary<TKey1, TKey2> primaryToSubKeyMapping = new Dictionary<TKey1, TKey2>();

    #endregion

    #region Properties

    public List<TValue> Values
    {
        get
        {
            return this.baseDictionary.Values.ToList();
        }
    }

    public int Count
    {
        get
        {
            return this.baseDictionary.Count;
        }
    }

    #endregion

    #region Indexers

    public TValue this[TKey2 subKey]
    {
        get
        {
            TValue item;
            if (this.TryGetValue(subKey, out item))
            {
                return item;
            }

            throw new KeyNotFoundException("Sub-key not found: " + subKey.ToString());
        }
    }

    public TValue this[TKey1 primaryKey]
    {
        get
        {
            TValue item;
            if (this.TryGetValue(primaryKey, out item))
            {
                return item;
            }

            throw new KeyNotFoundException("Primary key not found: " + primaryKey.ToString());
        }
    }

    #endregion

    #region Public Methods

    public void Associate(TKey2 subKey, TKey1 primaryKey)
    {
        if (!this.baseDictionary.ContainsKey(primaryKey))
        {
            throw new KeyNotFoundException(string.Format("The base dictionary does not contain the key '{0}'", primaryKey));
        }

        if (this.primaryToSubKeyMapping.ContainsKey(primaryKey))
        {
            // Remove the old mapping first
            TKey2 oldSubKey = this.primaryToSubKeyMapping[primaryKey];
            if (this.subDictionary.ContainsKey(oldSubKey))
            {
                this.subDictionary.Remove(oldSubKey);
            }

            this.primaryToSubKeyMapping.Remove(primaryKey);
        }

        this.subDictionary[subKey] = primaryKey;
        this.primaryToSubKeyMapping[primaryKey] = subKey;
    }

    public bool TryGetValue(TKey2 subKey, out TValue value)
    {
        value = default(TValue);

        TKey1 primaryKey;
        if (this.subDictionary.TryGetValue(subKey, out primaryKey))
        {
            return this.baseDictionary.TryGetValue(primaryKey, out value);
        }

        return false;
    }

    public bool TryGetValue(TKey1 primaryKey, out TValue value)
    {
        return this.baseDictionary.TryGetValue(primaryKey, out value);
    }

    public bool ContainsKey(TKey2 subKey)
    {
        TValue value;

        return this.TryGetValue(subKey, out value);
    }

    public bool ContainsKey(TKey1 primaryKey)
    {
        TValue value;

        return this.TryGetValue(primaryKey, out value);
    }

    public void Remove(TKey1 primaryKey)
    {
        if (this.primaryToSubKeyMapping.ContainsKey(primaryKey))
        {
            TKey2 subKey = this.primaryToSubKeyMapping[primaryKey];
            if (this.subDictionary.ContainsKey(subKey))
            {
                this.subDictionary.Remove(subKey);
            }

            this.primaryToSubKeyMapping.Remove(primaryKey);
        }

        this.baseDictionary.Remove(primaryKey);
    }

    public void Remove(TKey2 subKey)
    {
        TKey1 primaryKey = this.subDictionary[subKey];
        this.baseDictionary.Remove(primaryKey);

        this.primaryToSubKeyMapping.Remove(primaryKey);

        this.subDictionary.Remove(subKey);
    }

    public void Add(TKey1 primaryKey, TValue value)
    {
        this.baseDictionary.Add(primaryKey, value);
    }

    public void Add(TKey1 primaryKey, TKey2 subKey, TValue val)
    {
        this.Add(primaryKey, val);

        this.Associate(subKey, primaryKey);
    }

    public TValue[] CloneValues()
    {
        TValue[] values = new TValue[this.baseDictionary.Values.Count];

        this.baseDictionary.Values.CopyTo(values, 0);

        return values;
    }

    public TKey1[] ClonePrimaryKeys()
    {
        TKey1[] primaryKeys = new TKey1[this.baseDictionary.Keys.Count];

        this.baseDictionary.Keys.CopyTo(primaryKeys, 0);

        return primaryKeys;
    }

    public TKey2[] CloneSubKeys()
    {
        TKey2[] subKeys = new TKey2[this.subDictionary.Keys.Count];

        this.subDictionary.Keys.CopyTo(subKeys, 0);

        return subKeys;
    }

    public void Clear()
    {
        this.baseDictionary.Clear();

        this.subDictionary.Clear();

        this.primaryToSubKeyMapping.Clear();
    }

    public IEnumerator<KeyValuePair<TKey1, TValue>> GetEnumerator()
    {
        return this.baseDictionary.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<KeyValuePair<TKey1, TValue>>)this).GetEnumerator();
    }

    #endregion
}
