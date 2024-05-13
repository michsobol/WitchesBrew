using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] textLines;
    public float textSpeed;
    private int index;
    public bool Cont = true;

    void Start(){
        Cont = true;
        textComponent.text = string.Empty;
        DialogueStart();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == textLines[index]){
                LineNext();
            }else{
                bool Cont = false;
                StopAllCoroutines();
                textComponent.text = textLines[index];
            }
        }
    }

    void DialogueStart(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void LineNext(){
        if (index < textLines.Length - 1){
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
            //index = 0;
        }
    }

    public void setIndex(int dex){
        index = dex;
    }

    public int getIndex(){
        return index;
    }

    public void ResetLine(){
        textComponent.text = string.Empty;
        index = 0;
    }


    IEnumerator TypeLine(){
        foreach (char c in textLines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
