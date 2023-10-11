using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Sprite startAns;
    public Sprite greenCorrext;
    public Sprite redWrong;

    private void Start(){
        startAns = GetComponent<SpriteRenderer>().sprite;
        // Debug.Log(startSprite);
    }
    public void Answer(){
        if (isCorrect)
        {
            GetComponent<SpriteRenderer>().sprite = greenCorrext;
            quizManager.correct();
            // Debug.Log("CorrectAnswer");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = redWrong;
            StartCoroutine(ClearOptions());
            // quizManager.wrong();
            // Debug.Log("WrongAnswer");
        }
    }
    IEnumerator ClearOptions()
    {
        yield return new WaitForSeconds(1);
        quizManager.HideOp(gameObject);
    }
}