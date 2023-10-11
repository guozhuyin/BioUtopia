using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStomachSetting : MonoBehaviour
{
    private int chooseSence;
    void Start()
    {
        chooseSence = PlayerPrefs.GetInt("chooseSence");
        // Debug.Log(SceneManager.GetActiveScene( ).buildIndex);
        if( SceneManager.GetActiveScene( ).buildIndex == 0 && chooseSence == 1 ){
            // Debug.Log(chooseSence);
            SceneManager.LoadScene("ChangeAnyScenes") ;
            //玩家若儲存遊戲則會進入選擇場景
        }
    }
}
