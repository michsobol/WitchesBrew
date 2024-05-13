using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Customer : MonoBehaviour {
    
    // Start is called before the first frame update
    public bool hasBeenClicked = false;
    private Animator anim;
    private Animation animLeave;
    public Canvas parentCanvasOfDialogue;
    private GameObject dialogue;
    private GameObject newDialogue;
    public GameObject newCustom;
    private Sprite customerSprite;
    public static int coinNumber = 0;
    public TextMeshProUGUI coinText;
    //GameObject objectImLookingFor = null;
    GameObject potion;
    private string[] potionOptions = {"SleepPotion","EnergyPotion","FirePotion","FlightPotion","IllusionPotion","PosionPotion","SpeedPotion","HealingPotion","IcePotion","StrengthPotion","LovePotion","GrowthPotion","LightPotion","LightningPotion","ConcentrationPotion"};
    //GameObject[] taggedObjects;
    public string desiredPotion;
    Dialogue dialogueScript;
    //this particular class was miserable oh my goodness
    void Start()
    {
        dialogue = GameObject.FindGameObjectWithTag("dialogue");
        //Debug.Log(dialogue);
        dialogueScript = dialogue.GetComponent<Dialogue>();
        dialogue.SetActive(false);
        anim = this.gameObject.GetComponent<Animator>();
        anim.Play("BaseLayer.CustomerArrive", 0, 0.25f);
        dialogueScript.textLines[0] = "Hello!";
        dialogueScript.textLines[1] = "Goodbye.";
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        randomizePotion();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 1){
            checkPotion();
            dialogueScript.setIndex(1);
            dialogueScript.LineNext();
            //dialogue.SetActive(true);
            if(dialogueScript.getIndex() == 1 & dialogueScript.Cont == true){
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            anim.SetBool("TransOver",true);
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("BaseLayer.CustomerLeave")){
                //newDialogue = Instantiate(dialogue, new Vector3(500,193,0), Quaternion.identity);
                GameObject newCustomer = Instantiate(newCustom, new Vector3(-1217,-18,-9720), Quaternion.identity);
                //newDialogue.transform.SetParent(GameObject.Find("StoreCanvas").transform, false);
                newCustomer.transform.SetParent(GameObject.Find("StoreCanvas").transform, false);
                dialogue.SetActive(true);
                dialogueScript.ResetLine();
                Destroy(this.gameObject);
            }
            }
            //anim.Play("BaseLayer.CustomerLeave", 0, 0.25f);

        }
    }

    public void test(){
        Debug.Log("testing");
        hasBeenClicked = true;
    }

    public void initialDialogue(){
        hasBeenClicked = true;
        dialogue.SetActive(true);

    }

    public void checkPotion(){
        //check that mf potion!!!!
        GameObject potion = this.gameObject.transform.GetChild(0).gameObject;
        if(potion.name == desiredPotion){
            //dialogueScript.setIndex(2);
            //dialogueScript.setIndex(1);
            dialogueScript.textLines[1] = "This is what I wanted, here 15 coins";
            dialogueScript.textLines[0] = "Thank you so much!";
            dialogue.SetActive(true);
            coinNumber += 15;
            coinText.text = "coin: " + coinNumber;
            //dialogueScript.Cont = true;
           //dialogue.SetActive(false);

        }else{
            //dialogueScript.setIndex(2);
            dialogueScript.textLines[1] = "This isn't what I wanted, here are 5 coins";
            dialogueScript.textLines[0] = "Goodbye.";
            dialogue.SetActive(true);
            coinNumber += 5;
            coinText.text = "coin: " + coinNumber;
            //dialogueScript.Cont = true;
           //dialogue.SetActive(false);
        }
        //dialogue.SetActive(false);

    }

    public void randomizePotion(){
        //randomizes the potion that the player has to submit
        int randomNumber = Random.Range(0, 14);
        desiredPotion = potionOptions[randomNumber];
        dialogueScript.textLines[1] = ("I would like a " + desiredPotion + " please");
    }

   /* public void spawnPotion(string Name){
        //Debug.Log(Name);
        if (taggedObjects == null){
            taggedObjects = GameObject.FindGameObjectsWithTag("CustomPotion");
        }
        int index = 0;
        foreach (GameObject obj in taggedObjects){
            Debug.Log("boing");
            if(potion.name == Name){
                potion = taggedObjects[index];
                GameObject newPotion = Instantiate(potion, new Vector3(500,-200,0), Quaternion.identity);
                Debug.Log("boing");
                //newDialogue.transform.SetParent(GameObject.Find("StoreCanvas").transform, false);
                newPotion.transform.SetParent(GameObject.Find("CustomerArea").transform);
                break;
            }
            index++;
        }*/
      /* Debug.Log(taggedObjects);
       int index = 0;
        while(index < taggedObjects.Length){
            potion = taggedObjects[index];
            if(potion.name == Name){
                potion = taggedObjects[index];
                GameObject newPotion = Instantiate(potion, new Vector3(500,-200,0), Quaternion.identity);
                Debug.Log("boing");
                //newDialogue.transform.SetParent(GameObject.Find("StoreCanvas").transform, false);
                newPotion.transform.SetParent(GameObject.Find("StoreCanvas").transform);
                break;
            }
        }*/
        
        
    //}
    
}
