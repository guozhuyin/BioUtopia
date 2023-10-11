using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickNextScene : MonoBehaviour
{
    public void OnMouseUp (){
        SceneManager.LoadScene ( SceneManager.GetActiveScene( ).buildIndex + 1);
    }
}
