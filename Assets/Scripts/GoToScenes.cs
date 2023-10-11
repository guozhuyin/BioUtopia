using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScenes : MonoBehaviour
{
    public string goscene;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MainCamera")){
            Invoke ( "nS" , 1 );
        }
    }
    void nS ( ) {
        SceneManager.LoadScene ( goscene );
    }
}
