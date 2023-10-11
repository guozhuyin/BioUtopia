using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    GameObject mS;
    SpriteRenderer spriteRenderer;
    public Sprite [] faces; //設定幾個正面的圖
    public Sprite back; //設定背面的圖
    // List<int> TokenUpIndex = new List<int> { };
    public int faceIndex; //MatchingGameSetting.faceIndexes
    public bool matched = false;

    private void Start(){
        mS = GameObject.Find("Setting"); //開始時找場景物件 " "物件名稱
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseUp(){
        if (matched == false){
            MatchingGameSetting cS = mS.GetComponent<MatchingGameSetting>();
            if(spriteRenderer.sprite == back){
                    if(cS.TokenUp(this)){
                        spriteRenderer.sprite = faces[faceIndex];
                        // TokenUpIndex.Add(faceIndex);
                        cS.CheckTokens();
                    } //如果沒有兩張牌向上時，則可以翻牌
                }
            else{
                spriteRenderer.sprite = back;
                cS.TokenDown(this);
            } //如果有兩張牌向上時，則無法翻牌
        }
    }
    
}
