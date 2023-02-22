using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToStartMenu : MonoBehaviour
{
    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene(0);
    }
}
