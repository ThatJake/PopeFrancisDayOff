using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float lookAhead; 
    
    private void Update() //set camera to player and only move in x-axis
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
    }

}
