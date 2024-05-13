using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;


public class Buttons : MonoBehaviour
{
    //okay this is more than just button code but its what works
    private Animation anim;
    public GameObject camera;
    private Camera mainCamera;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject pausedText;
    public string nextScene;
    public static int coinNumber = 0;
    public TextMeshProUGUI coinText;
    public bool isPaused = false;

    Customer customScript;
    

    public void Start(){
        pausedText.SetActive(false);
        isPaused = false;
        anim = camera.GetComponent<Animation>();
        mainCamera = Camera.main;
        Debug.Log(anim);
        coinText.GetComponent<TextMeshProUGUI>();
        coinText.text = "coin: " + coinNumber;
        //https://www.youtube.com/watch?v=gFwf_T8_8po&t=63s&ab_channel=DALAB for how to call functions from other scripts
        customScript = GameObject.FindGameObjectWithTag("customer").GetComponent<Customer>();
    }

    //methods for all of the buttons on the main menu
    public void MoveLeft(){
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        //disable both buttons
        //have move left animation play for player camera
        anim.Play("CameraMoveLeft");
        //enable right button when animation ends
        rightButton.SetActive(true);
    }

    public void MoveRight(){
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        //disable both buttons
        //have move left animation play for player camera
        anim.Play("CameraMoveRight");
        //enable right button when animation ends
        leftButton.SetActive(true);
    }

    public void Menu_Button(){
        SceneManager.LoadScene(nextScene);
    }

    public void OnClick(InputAction.CallbackContext context){

        if(!context.started){
            return;
        }
        
        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if(!rayHit.collider){
            return;
        }
        customScript.initialDialogue();
        //Debug.Log(rayHit.collider.gameObject.name);
    }

    void Update (){
        //pause menu
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused == false){
                pausedText.SetActive(true);
                isPaused = !isPaused;
            } else if(isPaused == true){
                pausedText.SetActive(false);
                isPaused = !isPaused;
            }
        }
    }

}

