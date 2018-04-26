using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DialogueTree;

namespace TestDialogueTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dialogue dia = create_dialogue();
            run_dialogue(dia);
        }


        static void run_dialogue(Dialogue dia)
        {
            int node_id = 0;

            while (node_id != -1)
            {
                node_id = run_node(dia.nodes[node_id]);
            }
        }

        static int run_node(DialogueNode node)
        {
            int next_node = -1;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(node.Text);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Type a response number:");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < node.options.Count; ++i)
            {
                Console.WriteLine(String.Format("\t{0} : {1}", i + 1, node.options[i].Text));
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------");

            char key = Console.ReadKey().KeyChar;

            next_node = node.options[int.Parse(key.ToString()) - 1].DestinationNodeId;

            return next_node;
        }

        private static Dialogue create_dialogue()
        {
            Dialogue dia = new Dialogue();

            //----------------------------------------------------
            // Create the Nodes:
            //----------------------------------------------------
            DialogueNode node1 = new DialogueNode("Hi, welcome to the test Dialogue");
            dia.AddNode(node1);

            DialogueNode node2 = new DialogueNode("Well, that's rude. I don't want to talk to you!");
            dia.AddNode(node2);

            DialogueNode node3 = new DialogueNode("My name is [npc_name]. What it yours?");
            dia.AddNode(node3);

            DialogueNode node4 = new DialogueNode("Nice to meet you [player_name]");
            dia.AddNode(node4);

            //----------------------------------------------------
            // Create and connect the options:
            //----------------------------------------------------
            dia.AddOption("I'm out of here", node1, node2);
            dia.AddOption("Hello", node1, node3);

            dia.AddOption("Exit", node2, null);

            dia.AddOption("My name is [player_name]. Nice to meet you [npc_name]", node3, node4);
            dia.AddOption("Call me [player_name]", node3, node4);

            dia.AddOption("Exit", node4, null);

            XmlSerializer ser = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("test_dialogue.xml");

            ser.Serialize(writer, dia);

            return dia;



        }

        private static Dialogue load_dialog(string path)
        {            

            XmlSerializer ser = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dia = (Dialogue)ser.Deserialize(reader);

            return dia;
        }
    }
}
