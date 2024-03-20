using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HiddenObject : MonoBehaviour, IHiddenObject
{
    public string objectName;
    public Sprite objectSprite;
    private HiddenObjectList hiddenObjectList;

    public void onClickAction()
    {
        if (hiddenObjectList != null)
        {
            hiddenObjectList.hiddenObjectsList.Remove(this);
            hiddenObjectList.UpdateUI();

            if (hiddenObjectList.hiddenObjectsList.Count == 0)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;

                string levelNumberStr = currentSceneName.Split('_')[1];
                int levelNumber;
                bool success = int.TryParse(levelNumberStr, out levelNumber);

                if (success)
                {
                    int nextLevelNumber = levelNumber + 1;
                    string nextSceneName = "Level_" + nextLevelNumber + "_Scene";
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning("Failed to parse level number from scene name: " + currentSceneName);
                }
            }
        }
    }

    public void Awake()
    {
        this.objectName = gameObject.name;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            this.objectSprite = spriteRenderer.sprite;
        }

        hiddenObjectList = FindObjectOfType<HiddenObjectList>();

        if (hiddenObjectList != null)
        {
            hiddenObjectList.hiddenObjectsList.Add(this);
        }
    }
}
