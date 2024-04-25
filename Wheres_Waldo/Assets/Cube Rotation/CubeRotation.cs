using System.Collections;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // Adjust the speed of rotation here

    private bool isRotating = false;

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Rotate(Vector3.up, 90));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Rotate(Vector3.up, -90));
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Rotate(Vector3.right, -90));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Rotate(Vector3.right, 90));
            }
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle)
    {
        isRotating = true;

        Quaternion fromRotation = transform.rotation;
        Quaternion toRotation = Quaternion.Euler(axis * angle) * transform.rotation;


        float elapsedRotationTime = 0f;
        float totalRotationTime = 0.5f;

        while (elapsedRotationTime < totalRotationTime)
        {
            float t = elapsedRotationTime / totalRotationTime;
            transform.rotation = Quaternion.Slerp(fromRotation, toRotation, t);
            elapsedRotationTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = toRotation;

        isRotating = false;
    }
}
