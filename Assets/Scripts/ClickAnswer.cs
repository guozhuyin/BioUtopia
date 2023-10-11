using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnswer : MonoBehaviour
{
    public AnswerScript answerScript;

    private void OnMouseUp (){
        // Debug.Log("Click");
        answerScript.Answer();
    }
}
