using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Vector3 rotation = Vector3.up;
    [Range(0, 5)]
    public float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
