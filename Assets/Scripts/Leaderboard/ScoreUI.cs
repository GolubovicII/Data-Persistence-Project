using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public Button clearButton;

    private void Start()
    {
        FillLeaderboard();
        clearButton.onClick.AddListener(Clear);
    }

    private void Clear()
    {
        Debug.Log("Deleted!");
        PlayerPrefs.DeleteAll();
        ScoreManager.Instance.LoadScore();

        GameObject[] rows = GameObject.FindGameObjectsWithTag("Row");
        foreach (GameObject row in rows)
            Destroy(row);
    }

    private void FillLeaderboard()
    {
        var scores = ScoreManager.Instance.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
