using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScoreElement : UIBehaviour
{
    public Text nameUI;
    public Text scoreUI;
    public SaveFile.Score score;

    private string nameFormat;
    private string scoreFormat;

    protected override void Start()
    {
        base.Start();

        nameFormat = nameUI.text;
        scoreFormat = scoreUI.text;

        nameUI.text = string.Format(nameFormat, score.name);
        scoreUI.text = string.Format(scoreFormat, score.score);
    }
}
