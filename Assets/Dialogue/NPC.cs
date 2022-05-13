using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{

    private DialogueSystem dialogueSystem;

    public string Name;

    public GameObject activeItem;

    public GameObject deactiveItem;

    public GameObject doorBlock;

    public GameObject newQuest;
    public GameObject oldQuest;


    private PickupSystem pickupSystem;

    public bool seller = false;

    public GameObject bottle;

    [TextArea(5, 10)] public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); 
        pickupSystem = FindObjectOfType<PickupSystem>();
    }

    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (seller == true && pickupSystem.IsHoldingBottle == true)
        {
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            this.gameObject.GetComponent<NPC>().enabled = true;
            if ((other.gameObject.CompareTag("Player")) && Input.GetKeyDown(KeyCode.F))
            {
                if (activeItem.gameObject) activeItem.SetActive(true);
                if (deactiveItem.gameObject) deactiveItem.SetActive(false);
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
                pickupSystem.IsBottlePaid = true;
                doorBlock.SetActive(false);
                

            }
        }
        if (seller == false)
        {
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            this.gameObject.GetComponent<NPC>().enabled = true;
            if ((other.gameObject.CompareTag("Player")) && Input.GetKeyDown(KeyCode.F))
            {
                if (activeItem.gameObject) activeItem.SetActive(true);
                if (deactiveItem.gameObject) deactiveItem.SetActive(false);
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
                
            }
        }
    }
    
    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
        
    }
}

