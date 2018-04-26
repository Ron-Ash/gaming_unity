using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueOption
    {
        public string Text { get; set; }
        public int DestinationNodeId { get; set; }

        public DialogueOption() { }

        public DialogueOption(string text, int dest)
        {
            this.Text = text;
            this.DestinationNodeId = dest;
        }
    }
}
