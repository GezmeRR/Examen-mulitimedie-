using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public const int MaxScores = 10;

    public string playerName;
    public HighScoreElement highScorePrefab;

    private SaveFile saveFile;

    public SaveFile Savefile
    {
        get
        {
            if (saveFile == null)
            {
                saveFile = new SaveFile();
                saveFile.Load();
            }

            return saveFile;
        }
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void AddNewScore()
    {
        bool add = true;
        SaveFile.Score newScore = new SaveFile.Score() { name = playerName, score = SaveFile.newScore };

        for (int i = 0; i < Savefile.scores.Count; i++)
        {
            if (SaveFile.newScore < Savefile.scores[i].score)
            {
                Savefile.scores.Insert(i, newScore);
                add = true;
            }
        }

        if (add)
            Savefile.scores.Add(newScore);

        while (Savefile.scores.Count > MaxScores)
            Savefile.scores.RemoveAt(Savefile.scores.Count - 1);

        Savefile.Save();
    }

	void OnEnable ()
    {
	    foreach (SaveFile.Score score in Savefile.scores)
        {
            HighScoreElement highScoreElement = Instantiate(highScorePrefab);
            highScoreElement.score = score;
            highScoreElement.transform.SetParent(transform, false);
        }
	}
}
