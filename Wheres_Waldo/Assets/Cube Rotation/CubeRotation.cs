using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(Vector3.up, 90, Space.World);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(Vector3.up, 90, Space.World);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(Vector3.right, 90, Space.World);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.Rotate(Vector3.right, 90, Space.World);
        }
    }
}
