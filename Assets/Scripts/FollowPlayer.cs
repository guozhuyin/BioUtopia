using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playercamera;
    public Transform player;
    public Vector3 offset;
    void Update ( ) {
        playercamera.position = player.position + offset;
    }
}
