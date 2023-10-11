using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void FixedUpdate()
    {
        if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
            player.transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
            //rb.AddForce(force*Time.deltaTime,0,0);
        }
        if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)){
            player.transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
        }
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
            player.transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
        }
        if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
            player.transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
        }
    }
}
