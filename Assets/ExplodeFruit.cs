using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeFruit : MonoBehaviour
{
    [SerializeField] GameObject fruitFragments;
    [SerializeField] float score;
    [SerializeField][Range(-5f,0)] float yAxisToDestroy;
    //Cached References
    GameManager gameManager;
    Rigidbody myRigidbody;
    int hit = 1;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void LateUpdate()
    {
        if(myRigidbody.position.y < yAxisToDestroy)
        {
            Destroy(gameObject);
        }
    }
    //Called by Unity

    private void OnTriggerEnter(Collider other)
    {
        if (hit < 1) return;
        if (other.gameObject.tag == "Player")
        {
            hit--;
            gameManager.IncreaseScore(score);
            GameObject fragments = Instantiate(fruitFragments, transform.position, transform.rotation, transform.parent);
            fragments.transform.parent = this.transform;
        }
    }
    public float ReturnScore()
    {
        return score;
    }
}
