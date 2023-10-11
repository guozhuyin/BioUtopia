using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    void Start (){
        // GameObject BGR = GameObject.Find("BeyondGameRange");
    }
    void OnCollisionEnter (Collision collisionInfo){
        if (collisionInfo.collider.tag == "Obstacle")
        {
            StartCoroutine(BeyondGameRange());
        }
    }
    IEnumerator BeyondGameRange(){
        GameObject BGR = GameObject.Find("BeyondGameRange");
        // alert.SetActive(true);
        BGR.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        yield return new WaitForSeconds(1);
        BGR.GetComponent<Animator>().Play("TriggerDialogFadeOut");
        yield return new WaitForSeconds(1);
        // alert.SetActive(false);
    }
}
