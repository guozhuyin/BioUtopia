using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDisappear : MonoBehaviour
{
    public GameObject triggerDialogUI;
    public Sprite triggerDialogImage;
    public GameObject prize;
    void OnTriggerEnter (Collider other){
        if (other.CompareTag("MainCamera"))
        {
            triggerDialogUI.GetComponent<Image>().sprite = triggerDialogImage;
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
            StartCoroutine( Disappear() );
            // Debug.Log("OnTriggerEnter");
            
        }
    }
    // void OnTriggerExit (Collider other){
    //     if (other.CompareTag("MainCamera"))
    //     {
    //         triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeOut");
    //         prize.SetActive(false);
    //     }
    // }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);
        triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeOut");
        prize.SetActive(false);
    }
}
