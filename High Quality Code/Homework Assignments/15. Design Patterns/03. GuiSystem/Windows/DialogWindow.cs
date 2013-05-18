using System;
using System.Collections.Generic;

namespace GuiSystem.Windows
{
    public class DialogWindow : BaseWindow
    {
        private string question;
        private List<string> answers;

        public DialogWindow(string question, string[] answers)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException("question");
            }

            if (answers == null || answers.Length == 0)
            {
                throw new ArgumentException("answers");
            }

            this.question = question;
            this.answers = new List<string>(answers.Length);

            foreach (string answer in answers)
            {
                this.answers.Add(answer);
            }
        }

        protected override void DrawWindowSpecific()
        {
            this.Implementation.DrawTextBox(this.question, false);

            foreach (string answer in this.answers)
            {
                this.Implementation.DrawButton(answer);
            }
        }
    }
}