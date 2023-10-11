using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadRunningQuiz : MonoBehaviour
{
    private int correctCount ;
    private int scoreNum;
    void OnTriggerEnter ( Collider other ) {
        if ( other.CompareTag("MainCamera") )
        {
            scoreNum = PlayerPrefs.GetInt("scoreNum");
            correctCount = PlayerPrefs.GetInt("correctCount");
            if( correctCount < 6 ){
                scoreNum = scoreNum - (correctCount * 10);
                PlayerPrefs.SetInt("scoreNum",scoreNum) ;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
            }
        }
    }
}
