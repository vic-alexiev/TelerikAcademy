// ********************************
// <copyright file="Chef.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Kitchen
{
    using System.Text;

    /// <summary>
    /// Represents a chef.
    /// </summary>
    public class Chef
    {
        #region Private Fields

        /// <summary>
        /// Keeps the actions that are performed while cooking.
        /// </summary>
        private CookingLog cookingLog = new CookingLog();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the contents of the cooking log.
        /// </summary>
        public string Log
        {
            get
            {
                return this.cookingLog.ToString();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Describes the sequence of steps necessary to complete
        /// the soup-making process.
        /// </summary>
        public void MakeSoup()
        {
            Pot pot = this.GetPot();

            this.FillWithWater(pot);

            Potato potato = this.GetPotato();

            if (!potato.IsRotten)
            {
                if (!potato.IsPeeled)
                {
                    this.Peel(potato);
                }

                this.Wash(potato);
                this.Cut(potato);
            }
            else
            {
                this.MaybeNextTime(potato);
                return;
            }

            Carrot carrot = this.GetCarrot();

            if (!carrot.IsRotten)
            {
                if (!carrot.IsPeeled)
                {
                    this.Peel(carrot);
                }

                this.Wash(carrot);
                this.Cut(carrot);
            }
            else
            {
                this.MaybeNextTime(carrot);
                return;
            }

            this.PutIn(pot, potato);
            this.PutIn(pot, carrot);

            this.Boil(30);

            this.Success();
            return;
        }

        #endregion

        #region Private Methods

        private Pot GetPot()
        {
            Pot pot = new Pot();
            this.cookingLog.Add("A developer makes soup (Episode I - Invisible Threat)");
            this.cookingLog.Add(string.Format("Took a clean {0}. (What do they mean by 'clean'?)", pot));

            return pot;
        }

        private void FillWithWater(Utensil utensil)
        {
            string result = utensil.FillWithWater();
            this.cookingLog.Add(result);
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            this.cookingLog.Add(string.Format("Found a {0}. (Thank you, hamster.)", carrot));

            return carrot;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            this.cookingLog.Add(string.Format("Found a {0}. (The last one, the day is ours.)", potato));

            return potato;
        }

        private void MaybeNextTime(Vegetable vegetable)
        {
            this.cookingLog.Add(
                string.Format(
                "The {0} is rotten.\r\n" +
                "(They betrayed meeee! Wish I knew who bought this.)",
                vegetable));
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
            this.cookingLog.Add(
                string.Format(
                "Peeled the {0}.\r\n" +
                "(What a useless operation. This is outrageous!)",
                vegetable));
        }

        private void Wash(Vegetable vegetable)
        {
            this.cookingLog.Add(
                string.Format(
                "Washed the {0}.\r\n" +
                "(I think the aquarium should be in the kitchen.)",
                vegetable));
        }

        private void Cut(Vegetable vegetable)
        {
            this.cookingLog.Add(
                string.Format(
                "Cut the {0}. (Not a single drop of blood.\r\n" +
                "I was blind but now I see I was born to be a chef.)",
                vegetable));
        }

        private void PutIn(Utensil utensil, Vegetable vegetable)
        {
            string result = utensil.Add(vegetable);
            this.cookingLog.Add(result);
        }

        private void Boil(int minutes)
        {
            this.cookingLog.Add(
                string.Format(
                "Wait for {0} minutes and then...\r\n" +
                "What would my wife do without me?",
                minutes));
        }

        private void Success()
        {
            this.cookingLog.Add("Bon appetit, mon ami!");
        }

        #endregion
    }
}
