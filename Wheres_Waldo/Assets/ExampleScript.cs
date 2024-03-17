using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript: MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    private GameObject cube1, cube2;
    public bool isFrame, isPause;
    // Start is called before the first frame update
    void Start()
    {
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        cube1.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        cube1.GetComponent<Renderer>().material.color = Color.yellow;
        cube1.name = "Self";

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(-0.75f, 0.0f, 0.0f);
        cube2.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        cube2.GetComponent<Renderer>().material.color = Color.cyan;
        cube2.name = "World";

        xAngle = 1;
        yAngle = 1;
        zAngle = 0;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isFrame && !isPause) { 
            if (Input.GetKey(KeyCode.UpArrow)) {
                cube1.transform.Rotate(1, 0, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                cube1.transform.Rotate(-1, 0, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                cube1.transform.Rotate(0, 1, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                cube1.transform.Rotate(0, -1, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.Space)) {
                cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            }
        }
        isFrame = !isFrame;
    }
}
