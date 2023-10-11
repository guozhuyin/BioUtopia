using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RunningQuiz : MonoBehaviour
{
    public GameObject triggerDialogUI;
    public Sprite [] questions;
    private int i = 0;
    private float speed = 6.0f;
    private float xrange = 4.3f;
    private Vector3 camposition = new Vector3() ;
    Text score;
    private int correctCount;
    private int scoreNum;
    
    void Start()
    {
        i = 0;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreNum = PlayerPrefs.GetInt("scoreNum");
        score.text = ""+scoreNum;
        triggerDialogUI.GetComponent<Image>().sprite = questions [ i ];
        triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        camposition = transform.position;
    }
    void OnTriggerEnter (Collider other){
        if (other.GetComponent<Collider>().tag == "Answer" )
        {
            StartCoroutine ( NextQuiz( ) );
            // triggerDialogUI.GetComponent<Image>().sprite = questions [ i+1 ];
            // triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
            // triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
            correctCount++;
            PlayerPrefs.SetInt("correctCount", correctCount);
            scoreNum += 10;
            score.text=""+scoreNum;
            PlayerPrefs.SetInt("scoreNum", scoreNum);
            Debug.Log(scoreNum);
        }
        if (other.GetComponent<Collider>().name == "AnswerCube" && other.GetComponent<Collider>().tag != "Answer")
        {
            StartCoroutine ( NextQuiz( ) ); 
            // triggerDialogUI.GetComponent<Image>().sprite = questions [ i+1 ];
            // triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
            score.text=""+scoreNum;
            PlayerPrefs.SetInt("scoreNum", scoreNum);
        }
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Vector3.zero=new Vector3(0, 0, 0)
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler (new Vector3(0, 0, 0)); //固定Euler角度
        
        Vector3 newPosition = transform.position;
        
        if (newPosition.x > -xrange && newPosition.x < xrange)
        {
            if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
            }
            if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
            }
            if (newPosition.z <= 149.5)
            {
                transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
            }
        }
        else{
            newPosition.x = camposition.x;
            newPosition.y = camposition.y;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        newPosition.x = transform.position.x;
        newPosition.y = camposition.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
    IEnumerator NextQuiz(){
        i += 1;
        if ( i < 6 ){
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeOut");
            yield return new WaitForSeconds ( 0.3f );
            triggerDialogUI.GetComponent<Image>().sprite = questions [ i ];
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        }
        else{
            triggerDialogUI.GetComponent<Animator>().Play("TriggerDialogFadeOut");
        }
    }
}
