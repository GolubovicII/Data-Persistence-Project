using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuManager : MonoBehaviour
{
    private string playerName;

    private GameObject nameInputField;
    private float shakeDuration = 0.8f;
    private float shakeStrength = 2.0f;

    private void Awake()
    {
        nameInputField = GameObject.Find("Name InputField");
    }

    public void UpdateName()
    {
        playerName = nameInputField.GetComponent<TMP_InputField>().text;
        ScoreManager.Instance.playerName = playerName;
    }

    IEnumerator ShakeObjectRoutine(GameObject obj)
    {
        Vector3 startPos = obj.transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            Vector3 newPos = startPos + Random.insideUnitSphere * shakeStrength;
            newPos.y = obj.transform.position.y;
            newPos.z = obj.transform.position.z;

            obj.transform.position = newPos;
            yield return null;
        }

        obj.transform.position = startPos;
    }

    public void StartNew()
    {
        if (playerName == "" || playerName == null)
            StartCoroutine(ShakeObjectRoutine(nameInputField));
        else
            SceneManager.LoadScene(2);
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene(1);
    }
}
