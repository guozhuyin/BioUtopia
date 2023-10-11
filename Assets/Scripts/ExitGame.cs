using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public GameObject savePanel;
    public GameObject sayDialog;
    public Sprite saveOrNot;
    void OnTriggerEnter ( Collider other ) {
        if ( other.CompareTag("MainCamera") )
        {
            savePanel.SetActive(true);
            sayDialog.GetComponent<Image>().sprite = saveOrNot;
            sayDialog.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        }
    }
    public void SaveGame(){
        PlayerPrefs.SetInt("chooseSence", 1 );
        int chooseSence = PlayerPrefs.GetInt("chooseSence");
        Debug.Log(chooseSence);
        Application.OpenURL("https://forms.office.com/r/aTRVMME6JE");
        Debug.Log("Quit");
        Application.Quit();
    }
    public void NotSaveGame(){
        PlayerPrefs.SetInt("chooseSence", 0 );
        int chooseSence = PlayerPrefs.GetInt("chooseSence");
        Debug.Log(chooseSence);
        Application.OpenURL("https://forms.office.com/r/aTRVMME6JE");
        Debug.Log("Quit");
        Application.Quit();
    }
}
