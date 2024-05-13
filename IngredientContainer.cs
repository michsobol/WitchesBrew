using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientContainer : MonoBehaviour
{
    public Button yourButton;
    public GameObject ingredient;
    //private int counter;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        GameObject newIngred = Instantiate(ingredient, new Vector3(-740,-250,0), Quaternion.identity);
        newIngred.transform.SetParent(GameObject.Find("WorkroomCanvas").transform, false);
    
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
