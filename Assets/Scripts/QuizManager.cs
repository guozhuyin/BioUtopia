using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public List<QuizAndAnswer> QnA;
    public List<AnswerScript> Ass;
    public GameObject [] options;
    public int currentQuestion;
    public GameObject quizCube;
    public GameObject elf;
    // public GameObject nextPanel;
    public Text scoreTxt;
    public int scoreNum;

    public GameObject questionImg;
    private void Start(){
        // print(PlayerPrefs.GetInt("scoreNum"));
        quizCube.SetActive(true);
        // nextPanel.SetActive(false);
        scoreNum = PlayerPrefs.GetInt("scoreNum");
        scoreTxt.text = ""+scoreNum;
        Ass = GameObject.FindObjectsOfType<AnswerScript>().ToList(); //抓取所有AnswerScript的物件放到清單
        generateQuestion();
    }
    public void HideOp ( GameObject op ){
        op.SetActive(false);
    }
    public void ShowOp ( GameObject op ){
        op.SetActive(true);
    }
    void ShowAllQuizzes()
    {
        foreach(var m in Ass)
        {
            ShowOp(m.gameObject);
        }
    }
    void GameOver(){
        quizCube.SetActive(false);
        elf.SetActive(true);
        // nextPanel.SetActive(true);
        // scoreTxt.text = ""+score;
    }
    public void correct(){
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext()); //generateQuestion();
    }
    public void wrong( ){
        // scoreNum -= 10;
        // scoreTxt.text = ""+scoreNum;
        // PlayerPrefs.SetInt("scoreNum", scoreNum);
        // if(scoreNum < 0){
        //     scoreNum = 0;
        //     scoreTxt.text = ""+scoreNum;
        //     PlayerPrefs.SetInt("scoreNum", scoreNum);
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
        // }
        //StartCoroutine(ClearOptions());
        //QnA.RemoveAt(currentQuestion);
        //StartCoroutine(WaitForNext()); //generateQuestion();
    }
    void SetAnswers(){
        for (int i = 0; i < options.Length; i++)
        {
            options [i].GetComponent<AnswerScript>().isCorrect = false;
            //options [i].GetComponent <Image>().color = options [i].GetComponent <AnswerScript>().startColor;
            options[i].GetComponent<SpriteRenderer>().sprite = options [i].GetComponent <AnswerScript>().startAns;
            options[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = QnA[currentQuestion].answers[i];
            if(QnA[currentQuestion].correctAnswer == i+1 ){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(){
        if(QnA.Count>0){
            currentQuestion = Random.Range(0,QnA.Count);
            //questionTxt.text = QnA[currentQuestion].question;
            questionImg.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = QnA[currentQuestion].question;
            ShowAllQuizzes();
            SetAnswers();
        }
        else{
            // Debug.Log("OutOfQuestion");
            GameOver();
            // StartCoroutine(NextScene());
        }
    }
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        scoreNum += 10;
        scoreTxt.text = ""+scoreNum;
        PlayerPrefs.SetInt("scoreNum", scoreNum);
        generateQuestion();
    }
    // IEnumerator NextScene()
    // {
    //     yield return new WaitForSeconds(2);
    //     SceneManager.LoadScene("Scene12");
    // }
}
