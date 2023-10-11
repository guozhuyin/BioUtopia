using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScenes : MonoBehaviour
{
    void OnTriggerEnter ( Collider other ) {
        if ( other.CompareTag("MainCamera") )
        {
            PlayerPrefs.SetInt("chooseSence", 1);
            SceneManager.LoadScene ( "ChangeAnyScenes" );
            // SceneManager.LoadScene("Scene4") ;
        }
    }
}