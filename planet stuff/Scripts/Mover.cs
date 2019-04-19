using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{


    [Range(1, 100)]
    public float moveSpeed = 1;
    [Range(1, 100)]
    public float mouseSpeed = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 right = transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 up = transform.up * GetAxis(KeyCode.Z, KeyCode.X) * moveSpeed; ;
        Vector3 fwd = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

        transform.position += right + up + fwd;

        float yRot = GetAxis(KeyCode.Q, KeyCode.E);
        float xRot = GetAxis(KeyCode.R, KeyCode.F);
        transform.Rotate(new Vector3(xRot, yRot, 0));

        if (!Input.GetMouseButton(1))
            return;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(mouseY, mouseX, 0) * mouseSpeed);
    }

    float GetAxis(KeyCode neg, KeyCode pos)
    {
        return (Input.GetKey(neg) ? -1 : 0) + (Input.GetKey(pos) ? 1 : 0);
    }

}
