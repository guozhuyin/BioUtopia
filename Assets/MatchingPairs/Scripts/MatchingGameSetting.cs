using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchingGameSetting : MonoBehaviour
{
    GameObject token;
    public GameObject elf;
    public Text Score; //設定分數顯示位置
    int scoreNum = 0;
    MainToken tokenUp1 = null;
    MainToken tokenUp2 = null;
    List<int> faceIndexes = new List<int> { 0,1,2,3,4,5 };
    //List<int> TokenUpIndex = new List<int> { };
    public static System.Random rnd = new System.Random(); //rnd設為一個隨機函式
    public int shuffleNum = 0;
    //int[] visibleFaces = { -1 ,-2 }; //未翻牌的狀態

    private void Start()
    {
        PlayerPrefs.SetInt("scoreNum", 0);
        Score.text = "Score";
        float yPosition = 6.0f;
        float xPosition = 0f;
        float zPosition = 0.28f; //起始位置
        for (int i = 0; i < 5; i++)
        {
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(xPosition,yPosition,zPosition),Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum]; //隨機從List faceIndexes 0,1,2,3取圖片
            faceIndexes.Remove(faceIndexes[shuffleNum]); //每次取完要清除值，放入下一個值
            xPosition = xPosition + 5;
            if (i == 1) //faceIndexes.Count/2-2
            {
                yPosition = 2.0f;
                xPosition = -5f; //當i=2時，起始位置改變
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
    }
    public void TokenDown(MainToken tempToken)
    {
        if (tokenUp1 == tempToken)
        {
            tokenUp1 = null;
        } //如果tokenUp有值，則給null
        else if (tokenUp2 == tempToken)
        {
            tokenUp2 = null;
        }
    }
    public bool TokenUp(MainToken tempToken)
    {
        bool flipCard = true;
        if (tokenUp1 == null)
        {
            tokenUp1 = tempToken;
        } //如果tokenUp是null，則給this(face(faceindex))值
        else if (tokenUp2 == null)
        {
            tokenUp2 = tempToken;
            //TokenUpIndex.Add(tokenUp2.faceIndex);
            //Debug.Log(TokenUpIndex.Count);
        }
        else
        {
            flipCard = false;
        } //如果 tokenUp1、tokenUp2 有值，則不執行TokenUp
        return flipCard;
    }
    public void CheckTokens()
    {
        if (tokenUp1 != null && tokenUp2 != null)
        {
            if(tokenUp1.faceIndex == 0 && tokenUp2.faceIndex == 1 ||
            tokenUp1.faceIndex == 1 && tokenUp2.faceIndex == 0 ||
            tokenUp1.faceIndex == 2 && tokenUp2.faceIndex == 3 ||
            tokenUp1.faceIndex == 3 && tokenUp2.faceIndex == 2 ||
            tokenUp1.faceIndex == 4 && tokenUp2.faceIndex == 5 ||
            tokenUp1.faceIndex == 5 && tokenUp2.faceIndex == 4) {
                
                    AddScore ();
                    tokenUp1.matched = true;
                    tokenUp2.matched = true;
                    tokenUp1 = null;
                    tokenUp2 = null;
                
            }
        }
    }
    public void AddScore () {
        scoreNum += 10;
        Score.text=scoreNum.ToString();
        // if(scoreNum==30)
        //   {
        //     SceneManager.LoadScene("Scene6");
        //   }
        if(scoreNum >= 30)
          {
            elf.SetActive(true);
          }
        PlayerPrefs.SetInt("scoreNum", scoreNum);
        // Debug.Log(PlayerPrefs.GetInt("scoreNum"));
    }
    /*
    public bool TwoCadsUp(){
        bool cardsUp = false;
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0){
            cardsUp = true;
        }
        return cardsUp; //翻兩張牌的情況
    }
    public void AddVisibleFace (int index){
        if(visibleFaces[0] == -1){
            visibleFaces[0] = index;
        }
        else if(visibleFaces[1] == -2){
            visibleFaces[1] = index;
        }
    }
    public void RemoveVisibleFace (int index){
        if(visibleFaces[0] == index){
            visibleFaces[0] = -1;
        }
        else if(visibleFaces[1] == index){
            visibleFaces[1] = -2;
        }
    }
    public bool CheckMatch(){
        bool success = false;
        if(visibleFaces[0] == visibleFaces[1]){
            AddScore ();
            visibleFaces[0]=-1;
            visibleFaces[1]=-2;
            success=true;
        }
        return success;
    }
    */
    private void Awake(){
        token = GameObject.Find("Token");
    }
}
//TokenUpIndex [ ] 存取被翻的牌，如果 matched == false && TokenUpIndex [ ] ==2 則 TokenDown[TokenUpIndex]
