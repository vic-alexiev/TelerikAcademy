// ********************************
// <copyright file="Utensil.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Kitchen
{
    /// <summary>
    /// Represents a kitchen utensil.
    /// </summary>
    public abstract class Utensil
    {
        /// <summary>
        /// Fills the <see cref="Kitchen.Utensil"/> with water.
        /// </summary>
        /// <returns>The action performed.</returns>
        public string FillWithWater()
        {
            return string.Format(
                "Filled the {0} with water.\r\n" +
                "(Hope the fish won't get angry.)",
                this);
        }

        /// <summary>
        /// Puts the vegetable in the <see cref="Kitchen.Utensil"/>.
        /// </summary>
        /// <param name="vegetable">The vegetable.</param>
        /// <returns>The result of the action.</returns>
        public string Add(Vegetable vegetable)
        {
            return string.Format(
                "Put the {0} in the {1}.\r\n" +
                "(\"Double, double toil and trouble;\r\nFire burn, and cauldron bubble.\")",
                vegetable,
                this);
        }

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
