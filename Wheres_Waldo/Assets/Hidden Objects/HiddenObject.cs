using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObject : MonoBehaviour, IHiddenObject
{
    public void onClickAction()
    {
        Debug.Log("Clicked on a hidden object");
    }
}
