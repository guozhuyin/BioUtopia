using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WAMManager : MonoBehaviour
{
    public float ShowMonsterIntervalSeconds;
    public float countDownShowMonsterSeconds;
    public CameraSetting cameraSetting;
    public GameObject ground2;
    public GameObject elf;
    int MAX_MONSTERS_ON_SCREEN=3;
    public List<Monster> monsters;
    Text score;
    int scoreNum = 0;
    void Start()
    {
        ground2.SetActive(false);
        elf.SetActive(false);
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreNum = PlayerPrefs.GetInt("scoreNum");
        // scoreNum = 300;
        score.text = ""+scoreNum;
        monsters = GameObject.FindObjectsOfType<Monster>().ToList();
        HideAllMonsters();
        //ShowRandomMonster();
        countDownShowMonsterSeconds=ShowMonsterIntervalSeconds;//ResetShowMonserSecomds();
    }

    public void HideMonster ( GameObject monster){
        monster.SetActive(false);
    }
    public void ShowMonster ( GameObject monster){
        monster.SetActive(true);
    }
    public void AddScore () {
        scoreNum += 10;
        score.text=scoreNum.ToString();
        PlayerPrefs.SetInt("scoreNum", scoreNum);
    }
    void HideAllMonsters()
    {
        foreach(var m in monsters)
        {
            HideMonster(m.gameObject);
        }
    }
    List<Monster> HiddenMonsters
    {
        get
        {
           var result=new List<Monster>();
           foreach(var m in monsters)
           {
              if(!m.IsActive)
              {
                result.Add(m);
              }
           }
           return result;
        }
    }
    int MonsterCountOnScreen
    {
        get{
            int result=0;
            foreach(var m in monsters)
            {
                if(m.IsActive)
                {
                    result+=1;
                }
            }
            return result;
        }
    }
    void ShowRandomMonster()
    {
       int r=Random.Range(0,HiddenMonsters.Count);
       Monster m=HiddenMonsters[r];
       ShowMonster(m.gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        countDownShowMonsterSeconds-=Time.fixedDeltaTime;

        if(countDownShowMonsterSeconds<=0)
        {
            countDownShowMonsterSeconds=ShowMonsterIntervalSeconds;
            if(MonsterCountOnScreen<MAX_MONSTERS_ON_SCREEN)
            {
                ShowRandomMonster();
            }
        }
        if (scoreNum >= 300) {
            ground2.SetActive(true);
            elf.SetActive(true);
            // cameraSetting = FindObjectOfType<CameraSetting> ().GetComponent<CameraSetting> ();
            // cameraSetting.enabled = true;
            PlayerPrefs.SetInt("scoreNum", 0);
        }
    }
}
