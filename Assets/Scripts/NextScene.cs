using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        int chooseSence = PlayerPrefs.GetInt("chooseSence");
        if (other.CompareTag("MainCamera") && chooseSence == 1)
        {
            Invoke ( "cAS" , 1 );
        }
        else if(other.CompareTag("MainCamera")){
            Invoke ( "nS" , 1 );
        }
    }
    void nS ( ) {
        SceneManager.LoadScene ( SceneManager.GetActiveScene( ).buildIndex + 1 );
    }
    void cAS ( ) {
        SceneManager.LoadScene("ChangeAnyScenes") ;
    }
}
