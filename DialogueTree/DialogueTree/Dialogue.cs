using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> nodes;

        public Dialogue()
        {
            nodes = new List<DialogueNode>();
        }

        public void AddNode(DialogueNode node)
        {
            if (node != null)
            {
                nodes.Add(node);
                node.NodeId = nodes.IndexOf(node);
            }
        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest)
        {
            if (!nodes.Contains(dest))
            {
                AddNode(dest);
            }

            if (!nodes.Contains(node))
            {
                AddNode(node);
            }

            DialogueOption opt;

            if (dest == null)
            {
                opt = new DialogueOption(text, -1);
            }
            else
            {
                opt = new DialogueOption(text, dest.NodeId);
            }
            node.options.Add(opt);
        }

    }
}
