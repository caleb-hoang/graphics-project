using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBox : MonoBehaviour
{
    public Text level;

    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string levelNumberStr = currentSceneName.Split('_')[1];
        level.text = "Level " + levelNumberStr;
    }
}
