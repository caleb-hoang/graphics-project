using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    private CursorControls controls;

    private Camera mainCamera;

    private void Awake()
    {
        controls = new CursorControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // If we hit an object
            if (hit.collider != null)
            {
                // Check if clicked object implements hidden object interface
                IHiddenObject hiddenObject = hit.collider.GetComponent<IHiddenObject>();
                if (hiddenObject != null)
                {
                    hiddenObject.onClickAction();
                } else
                {
                    Debug.Log("Clicked on a non-hidden object");
                }
            }
        }
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => DetectObject();
    }

    void Update()
    {
    }
}
