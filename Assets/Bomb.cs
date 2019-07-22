using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //cached References
    GameManager myGameManager;
    private void Awake()
    {
        myGameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            return;
        }
        else
        {
            myGameManager.GameEnd();
        }
    }
}
