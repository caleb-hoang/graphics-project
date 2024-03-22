using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HiddenObjectList : MonoBehaviour
{
    public List<HiddenObject> hiddenObjectsList = new List<HiddenObject>();
    public GameObject hiddenObjectDisplayItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PopulateHiddenObjectUI();
    }

    public void UpdateUI()
    {
        ClearHiddenObjectUI();
        PopulateHiddenObjectUI();
    }

    public HiddenObject FindHiddenObjectByObjectName(string objectName)
    {
        HiddenObject hiddenObject = hiddenObjectsList.FirstOrDefault(obj => obj.objectName.Equals(objectName));

        if (hiddenObject != null)
        {
            return hiddenObject;

        }
        else
        {
            Debug.LogWarning("Object with name " + objectName + " could not found.");
            return null;
        }
    }

    public bool AreAllHiddenObjectsFound()
    {
        return hiddenObjectsList.All(obj => obj.isFound);
    }

    void ClearHiddenObjectUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    void PopulateHiddenObjectUI()
    {
        foreach (HiddenObject hiddenObject in hiddenObjectsList)
        {
            if (hiddenObject.isFound == false)
            {
                GameObject hiddenObjectDisplayItem = Instantiate(hiddenObjectDisplayItemPrefab, transform);

                Transform imageChild = hiddenObjectDisplayItem.transform.Find("Hidden Object Sprite");
                Transform textChild = hiddenObjectDisplayItem.transform.Find("Hidden Object Name");

                Image imageComponent = imageChild.GetComponent<Image>();
                Text textComponent = textChild.GetComponent<Text>();

                if (textComponent != null)
                {
                    textComponent.text = hiddenObject.objectName;
                }

                if (imageComponent != null)
                {
                    imageComponent.sprite = hiddenObject.objectSprite;
                }
            }
        }
    }
}
