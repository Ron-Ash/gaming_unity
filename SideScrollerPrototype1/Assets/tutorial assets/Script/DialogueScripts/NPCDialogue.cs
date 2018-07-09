using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueTree;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjectScript = null;
    public PlayerInventory inventory;


    private Dialogue dia;

    private GameObject dialogue_window;
        
    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit;

    private int selected_option = -2;

    public string DialogueDataFilePath;

    public GameObject DialogueWinowsPrefab;

    // Use this for initialization
    void Start()
    {

        dia = Dialogue.LoadDialogue("./Assets/tutorial assets/Script/DialogueScripts/" + DialogueDataFilePath);

        var canvas = GameObject.Find("DialogueCanvas");
        dialogue_window = Instantiate<GameObject>(DialogueWinowsPrefab);
        dialogue_window.transform.SetParent(canvas.transform);

        RectTransform dia_window_transform = (RectTransform)dialogue_window.transform;

        dia_window_transform.localPosition = new Vector3(0, 0, 0);

        node_text = GameObject.Find("node_text");
        option_1 = GameObject.Find("Option1");
        option_2 = GameObject.Find("Option2");
        option_3 = GameObject.Find("Option3");
        exit = GameObject.Find("Button_Exit");


        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); });

        dialogue_window.SetActive(false);
        DialogueWinowsPrefab.SetActive(false);

    }

    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    public void SetSelectedOption(int x)
    {
        selected_option = x;
    }

    public IEnumerator run()
    {

        // create an indexer, set it to 0 - the dialogue Start node.
        int node_id = 0;

        // while the next node is not an exit node, traverse the dialogue tree based on the user input
        while (node_id != -1)
        {
            display_node(dia.nodes[node_id]);

            selected_option = -2;
            while (selected_option == -2)
            {
                // this just pauses this function for 0.25 seconds until the user selects a value which will make 
                // selected_option to be != -2
                yield return new WaitForSeconds(0.25f);
            }

            // the user chose an option so now node_id is equal to the selected option. and we'll go back in the loop and 
            // display it.
            node_id = selected_option;
        }
        DialogueWinowsPrefab.SetActive(false);
     
    }

    private void display_node(DialogueNode node)
    {
        DialogueWinowsPrefab.SetActive(true);
        // we get the Text componenet of the node_text and setting it's text value to the node.Text value from our DialogueTree
        node_text.GetComponent<Text>().text = node.Text;

        // set all the button's to inactive (invisible)
        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        for (int i = 0; i < node.options.Count; i++)
        {
            switch (i)
            {
                case 0:
                    {
                        set_option_button(option_1, node.options[i]);
                        break;
                    }
                case 1:
                    {
                        set_option_button(option_2, node.options[i]);
                        break;
                    }
                case 2:                
                    {
                        set_option_button(option_3, node.options[i]);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    private void set_option_button(GameObject button, DialogueOption opt)
    {
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = opt.Text;
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(opt.DestinationNodeId); });           
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            RunDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(dialogue_window);
            Start();
        }
    }
}
