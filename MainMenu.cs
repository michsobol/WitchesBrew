using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextScene;
    public string instructionpage;
    public GameObject instruct_text;
    public GameObject credit_text;
    Dialogue customScript;

    //methods for all of the buttons on the main menu
    public void Start_Button(){
        SceneManager.LoadScene(nextScene);
    }

    public void Exit_Button(){
        Application.Quit();
    }

    public void Instuctions(){
        instruct_text.SetActive(true);
        credit_text.SetActive(false);
    }

    public void Credits(){
        credit_text.SetActive(true);
        instruct_text.SetActive(false);
    }
}
