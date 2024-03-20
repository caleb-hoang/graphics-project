using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectList : MonoBehaviour
{
    public List<HiddenObject> hiddenObjectsList = new List<HiddenObject>();
    public GameObject hiddenObjectPrefab;

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

    void ClearHiddenObjectUI()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    void PopulateHiddenObjectUI()
    {
        foreach (HiddenObject hiddenObject in hiddenObjectsList)
        {
            GameObject hiddenObjectDisplayItem = Instantiate(hiddenObjectPrefab, transform);
            
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
