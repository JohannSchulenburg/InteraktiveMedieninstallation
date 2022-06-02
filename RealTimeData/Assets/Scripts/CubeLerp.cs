using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLerp : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime);
    }
}
