using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject NextLevelElf;
    public GameObject nextLevel;
    // public GameObject sayDialog; //對話框

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MainCamera")){
            NextLevelElf.SetActive(false);
            nextLevel.SetActive(true);
        }
    }
    // IEnumerator DisableSayDialog (){
    //     int chooseSence = PlayerPrefs.GetInt("chooseSence");
    //     Debug.Log(chooseSence);
    //     yield return new WaitForSeconds ( 10.0f );
    //     if( sayDialog.name == "SayDialog" && chooseSence == 1 ){
    //         Debug.Log(chooseSence);
    //         sayDialog.SetActive(false);//玩家若完成遊戲不會出現對話框
    //     }
    // }
}
