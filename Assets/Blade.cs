using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    //cached References
    SphereCollider myCollider;
    float distanceTolerance = 0.1f;
    Vector3 lastPos;
    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        myCollider.enabled = IsMouseMoving();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving()
    {
        Vector3 currentPos = transform.position;
        float traveled = (lastPos - currentPos).magnitude;
        lastPos = currentPos;
        if (traveled > distanceTolerance)
            return true;
        else
            return false;
    }
}
