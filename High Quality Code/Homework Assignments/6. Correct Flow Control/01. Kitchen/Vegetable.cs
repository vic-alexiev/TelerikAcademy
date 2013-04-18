// ********************************
// <copyright file="Vegetable.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Kitchen
{
    /// <summary>
    /// Represents a vegetable.
    /// </summary>
    public abstract class Vegetable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="Kitchen.Vegetable"/> is rotten.
        /// </summary>
        public bool IsRotten { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="Kitchen.Vegetable"/> is peeled.
        /// </summary>
        public bool IsPeeled { get; set; }

        /// <summary>
        /// Returns this type's name.
        /// </summary>
        /// <returns>The name of the type converted to lowercase.</returns>
        public override string ToString()
        {
            return this.GetType().Name.ToLower();
        }
    }
}
