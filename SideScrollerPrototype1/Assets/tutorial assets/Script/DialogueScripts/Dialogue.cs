using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> nodes;

        public Dialogue()
        {
            nodes = new List<DialogueNode>();
        }

        public static Dialogue LoadDialogue(string path)
        {

            XmlSerializer ser = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dia = (Dialogue)ser.Deserialize(reader);

            return dia;
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
