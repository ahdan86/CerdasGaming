using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRefill : MonoBehaviour
{
    private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            //player.GetComponent<PlayerShoot>().totalBullet = 100;
        }
    }
}
