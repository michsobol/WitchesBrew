using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBrew : MonoBehaviour
{
    private GameObject brew;
    private GameObject potion;
    // Start is called before the first frame update
    void Start()
    {
        brew = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //check if there are two ingredients added to the pot, if so then go to brew function
        if(transform.childCount == 2){
            potion = potionDecide();
            Debug.Log(potion.name);
            //spawns appropriate potion
            GameObject newPotion = Instantiate(potion, new Vector3(740,-250,0), Quaternion.identity);
            newPotion.transform.SetParent (GameObject.Find("WorkroomCanvas").transform, false);
            //Debug.Log(potion.name + " is added!");
            //deletes the objects in the pot
            Destroy(brew.transform.GetChild(0).gameObject);
            Destroy(brew.transform.GetChild(1).gameObject);
        }
        
    }

    //brew function: checks which two objects are in the pot
    GameObject potionDecide(){
        GameObject newPotion = new GameObject();
        GameObject ingredOne = brew.transform.GetChild(0).gameObject;
        GameObject ingredTwo = brew.transform.GetChild(1).gameObject;

        //super long switch statement because I kinda didn't know a better way to do this... oops
        switch(ingredOne.name){
            case "YellowFlower(Clone)" :
                if(ingredTwo.name == "YellowFlower(Clone)"){
                    newPotion = GameObject.Find("LightningPotion");
                }
                if(ingredTwo.name == "BlueFlower(Clone)"){
                    newPotion= GameObject.Find("SleepPotion");
                }
                if(ingredTwo.name == "RedFlower(Clone)"){
                    newPotion= GameObject.Find("EnergyPotion");
                }
                if(ingredTwo.name == "WhiteFlower(Clone)"){
                    newPotion= GameObject.Find("LightPotion");
                }
                if(ingredTwo.name == "GreenFlower(Clone)"){
                    newPotion= GameObject.Find("GrowthPotion");
                }
                break;
            case "RedFlower(Clone)" :
                if(ingredTwo.name == "YellowFlower(Clone)"){
                    newPotion= GameObject.Find("EnergyPotion");
                }
                if(ingredTwo.name == "BlueFlower(Clone)"){
                    newPotion= GameObject.Find("IllusionPotion");
                }
                if(ingredTwo.name == "RedFlower(Clone)"){
                    newPotion= GameObject.Find("FirePotion");
                }
                if(ingredTwo.name == "WhiteFlower(Clone)"){
                    newPotion= GameObject.Find("LovePotion");
                }
                if(ingredTwo.name == "GreenFlower(Clone)"){
                    newPotion= GameObject.Find("StrengthPotion");
                }
                break;
            case "BlueFlower(Clone)" :
                if(ingredTwo.name == "RedFlower(Clone)"){
                    newPotion= GameObject.Find("IllusionPotion");
                }
                if(ingredTwo.name == "YellowFlower(Clone)"){
                    newPotion= GameObject.Find("SleepPotion");
                }
                if(ingredTwo.name == "BlueFlower(Clone)"){
                    newPotion= GameObject.Find("SpeedPotion");
                }
                if(ingredTwo.name == "WhiteFlower(Clone)"){
                    newPotion= GameObject.Find("IcePotion");
                }
                if(ingredTwo.name == "GreenFlower(Clone)"){
                    newPotion= GameObject.Find("ConcentrationPotion");
                }
                break;
            case "WhiteFlower(Clone)" :
                if(ingredTwo.name == "YellowFlower(Clone)"){
                    newPotion= GameObject.Find("LightPotion");
                }
                if(ingredTwo.name == "RedFlower(Clone)"){
                    newPotion= GameObject.Find("LovePotion");
                }
                if(ingredTwo.name == "BlueFlower(Clone)"){
                    newPotion= GameObject.Find("IcePotion");
                }
                if(ingredTwo.name == "WhiteFlower(Clone)"){
                    newPotion= GameObject.Find("FlightPotion");
                }
                if(ingredTwo.name == "GreenFlower(Clone)"){
                    newPotion= GameObject.Find("HealingPotion");
                }
                break;
            case "GreenFlower(Clone)" :
                if(ingredTwo.name == "YellowFlower(Clone)"){
                    newPotion= GameObject.Find("GrowthPotion");
                }
                if(ingredTwo.name == "RedFlower(Clone)"){
                    newPotion= GameObject.Find("StrengthPotion");
                }
                if(ingredTwo.name == "BlueFlower(Clone)"){
                    newPotion= GameObject.Find("ConcentrationPotion");
                }
                if(ingredTwo.name == "WhiteFlower(Clone)"){
                    newPotion= GameObject.Find("HealingPotion");
                }
                if(ingredTwo.name == "GreenFlower(Clone)"){
                    newPotion= GameObject.Find("PoisonPotion");
                }
                break;
            default:
                //Debug.Log(ingredOne.name + " " + ingredTwo.name);
                break;
        }
        //Debug.Log(ingredOne.name + " " + ingredTwo.name);
        return newPotion;
        
    }
    
}
