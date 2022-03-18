using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform dest;
    public GameObject player;

    public float camSpeed;
    public Camera playerCam;
    

    public void Awake()
    {
        playerCam.enabled = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //moveCamUp();
        //flip();
        player.transform.position = dest.transform.position;
        //moveCamDown();
    }

    


}
