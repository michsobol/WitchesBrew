using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro.Examples;

public class DragDrop : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public Canvas parentCanvasOfImageToMove;

   private RectTransform rectTransform;
   //private Rigidbody2D rigidBody;
   private Image image;
    private Vector2 pos;
    private GameObject potion;
     //Vector3 NewPos = new Vector3(1980, 1080, 0);
   public Camera cam;
   Customer customScript;

    public void OnBeginDrag(PointerEventData eventData){
        image.color = new Color32(255,255,255,170);
    }
    public void OnEndDrag(PointerEventData eventData){
        image.color = new Color32(255,255,255,255);

        //Vector3 vec = new Vector3(pos.x, pos.y, 0);
        bool customerCheckX = ((pos.x <= 120 & pos.x >= -120));
        bool customerCheckY = ((pos.y <= 320 & pos.y >= -180));
        bool customerCheck = (customerCheckX & customerCheckY);

        //Debug.Log(leftmostX + " " + rightmostX + " " + pos.x);
        Debug.Log(customerCheck);
        

        //check if the image is ontop of the brewSpace, if so then make it a child of the brewspace and disable it
        if((pos.x >= -180 & pos.x <= 180) & (pos.y >= -75 & pos.y <= 75) & (this.gameObject.tag == "ingredient")){
            GameObject item = this.gameObject;
            item.transform.SetParent(GameObject.Find("Brewspace").transform, false);
            item.SetActive(false);
        //check for potion in contact with the customer
        }else if( customerCheck & (this.gameObject.tag == "potion")){
            GameObject item = this.gameObject;
            item.transform.SetParent(GameObject.Find("Customer").transform, false);
            item.SetActive(false);
        }//else if(pos.x == (-cam.pixelWidth/2)  & (this.gameObject.tag == "potion") ){
            //Debug.Log("beep");
            //customScript.spawnPotion(this.gameObject.name);
            //Destroy(this.gameObject);
        else{
            //Destroy(item);
            return;
        }
        //else do nothing
    }

   
    
    public void OnDrag(PointerEventData eventData){
        //Solution to UI issue from https://stackoverflow.com/questions/37244471/click-and-drag-a-gameobject-in-a-overlay-canvas-in-unity
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, eventData.position, parentCanvasOfImageToMove.worldCamera, out pos);
        pos.x = Mathf.Clamp(pos.x, -cam.pixelWidth / 2, cam.pixelWidth / 2);
        pos.y = Mathf.Clamp(pos.y, -cam.pixelHeight / 2, cam.pixelHeight / 2);
        image.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);

       
    }
   
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        customScript = GameObject.FindGameObjectWithTag("customer").GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
