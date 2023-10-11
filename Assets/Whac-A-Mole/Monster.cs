using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public WAMManager wamManager;
    public float maxSecondsOnScreen=2.5f;
    public float currenSecondsOnScreen=0;
    void Start()
    {
        wamManager = FindObjectOfType<WAMManager> ().GetComponent<WAMManager> ();
        currenSecondsOnScreen=maxSecondsOnScreen;
    }
    private void OnMouseDown(){
        wamManager.AddScore();
        currenSecondsOnScreen=maxSecondsOnScreen;
        wamManager.HideMonster(gameObject);
    }
    public bool IsActive=>gameObject.activeInHierarchy;
    bool OnScreenTimeUp=>currenSecondsOnScreen<0;
    void FixedUpdate()
    {
       if(IsActive)//TryCountDownToHide();
       {
        currenSecondsOnScreen-=Time.fixedDeltaTime;//CountDownCurrenSecondsOnScreen
       }
       if(OnScreenTimeUp)
       {
        wamManager.HideMonster(gameObject); 
        currenSecondsOnScreen=maxSecondsOnScreen;//ResetCurrenSecondsOnScreen   
       } //TryCountDownToHide();
    }
}
