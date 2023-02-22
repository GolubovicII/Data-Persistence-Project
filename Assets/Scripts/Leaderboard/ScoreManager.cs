using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    public string playerName;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

    public void LoadScore()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }
}
