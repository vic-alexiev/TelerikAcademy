using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(

    Format.UserDefined, /// Binary Serialization because of StringBuilder
    IsInvariantToOrder = false, /// order changes the result
    IsInvariantToNulls = true,  /// nulls don't change the result
    IsInvariantToDuplicates = false, /// duplicates change the result
    MaxByteSize = -1
    )]

public struct concat : IBinarySerialize
{
    private StringBuilder _accumulator;
    private string _delimiter;

    /// <summary>
    /// IsNull property
    /// </summary>
    public Boolean IsNull { get; private set; }

    public void Init()
    {
        _accumulator = new StringBuilder();
        _delimiter = string.Empty;
        this.IsNull = true;
    }

    public void Accumulate(SqlString Value, SqlString Delimiter)
    {
        if (!Delimiter.IsNull
            & Delimiter.Value.Length > 0)
        {
            _delimiter = Delimiter.Value; /// save for Merge
            if (_accumulator.Length > 0) _accumulator.Append(Delimiter.Value);

        }
        _accumulator.Append(Value.Value);
        if (Value.IsNull == false) this.IsNull = false;
    }
    /// <summary>
    /// Merge onto the end 
    /// </summary>
    /// <param name="Group"></param>
    public void Merge(concat Group)
    {
        /// add the delimiter between strings
        if (_accumulator.Length > 0
            & Group._accumulator.Length > 0) _accumulator.Append(_delimiter);

        ///_accumulator += Group._accumulator;
        _accumulator.Append(Group._accumulator.ToString());

    }

    public SqlString Terminate()
    {
        // Put your code here
        return new SqlString(_accumulator.ToString());
    }

    /// <summary>
    /// deserialize from the reader to recreate the struct
    /// </summary>
    /// <param name="r">BinaryReader</param>
    void IBinarySerialize.Read(System.IO.BinaryReader r)
    {
        _delimiter = r.ReadString();
        _accumulator = new StringBuilder(r.ReadString());

        if (_accumulator.Length != 0) this.IsNull = false;
    }

    /// <summary>
    /// searialize the struct.
    /// </summary>
    /// <param name="w">BinaryWriter</param>
    void IBinarySerialize.Write(System.IO.BinaryWriter w)
    {
        w.Write(_delimiter);
        w.Write(_accumulator.ToString());
    }
}