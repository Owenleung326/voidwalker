using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeUp : MonoBehaviour
{
    public GameObject bridge;
    public GameObject bridgeSwitch;
    public GameObject stairs;

    void Start()
    {
        bridge.SetActive(false);
        stairs.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            if (bridge.activeSelf == false)
            {
                bridge.SetActive(true);
                stairs.SetActive(true);
            }   else
            {
                Destroy(bridge);
            }
        }
        Destroy(this.gameObject);
    }
}
