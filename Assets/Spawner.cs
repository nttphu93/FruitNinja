using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objPrefabs;
    [SerializeField] float timeUntilNextSpawn = 2f;
    [SerializeField] int fruitsToLauch = 10;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float minY = 5f;
    [SerializeField] float maxY = 10f;
    // Start is called before the first frame update
    bool readyToLauch = true;
    private void Update()
    {
        while (fruitsToLauch > 0 && readyToLauch)
        {
            StartCoroutine(LauchFruit());
        }
    }
    IEnumerator LauchFruit()
    {
        readyToLauch = false;
        fruitsToLauch--;
        GameObject fruit = Instantiate(objPrefabs[RandomIndex()], transform.position, Quaternion.identity, transform.parent) as GameObject;
        fruit.transform.parent = this.transform;
        Rigidbody fruitRigidbody = fruit.GetComponent<Rigidbody>();
        if(!fruitRigidbody) { Debug.LogError(fruit.name + "Doesn't have rigidbody"); }
        fruitRigidbody.velocity = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        yield return new WaitForSeconds(timeUntilNextSpawn);
        readyToLauch = true;
    }

    private int RandomIndex()
    {
        int random = Random.Range(0, objPrefabs.Length);
        return random;
    }
}
