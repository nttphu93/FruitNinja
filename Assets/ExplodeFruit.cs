using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeFruit : MonoBehaviour
{
    [SerializeField] GameObject fruitFragments;

    //Called by Unity
    private void OnMouseDown()
    {
        StartCoroutine(ExplodingFruit());
    }
    IEnumerator ExplodingFruit()
    {
        //gameObject.SetActive(false);
        GameObject fragments = Instantiate(fruitFragments, transform.position, transform.rotation, transform.parent);
        yield return new WaitForSeconds(2f);
        Destroy(fragments);
    }
}
