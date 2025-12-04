using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLock : MonoBehaviour
{


    private Vector3 worldPos;
    void Start()
    {
        worldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = worldPos;
    }
}
