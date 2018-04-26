using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueNode
    {
        public int NodeId { get; set;}
        public string Text { get; set; }
        public List<DialogueOption> options;

        public DialogueNode()
        {
            options = new List<DialogueOption>();
        }

        public DialogueNode(string text)
        {
            this.Text = text;
            options = new List<DialogueOption>();
        }
    }
}
