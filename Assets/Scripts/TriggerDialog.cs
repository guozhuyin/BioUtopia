using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialog : MonoBehaviour
{
    public GameObject triggerDialogUI;
    public Sprite triggerDialogImage;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MainCamera")){
            // Debug.Log("OnTriggerEnter");
            // triggerDialogue.enabled = true;
            triggerDialogUI.GetComponent<Image>().sprite = triggerDialogImage;
            // triggerDialogUI.SetActive(true); Animator
            // dialogAnim.Play("TriggerDialogFadeIn");
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.CompareTag("MainCamera")){
            // Debug.Log("OnTriggerExit");
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeOut");
            // dialogAnim.Play("TriggerDialogFadeOut");
            // triggerDialogUI.SetActive(false);
            // Invoke( "disableTriggerDialogUI" , 1.0f );
            // triggerDialogue.enabled = false;
        }
    }
}
