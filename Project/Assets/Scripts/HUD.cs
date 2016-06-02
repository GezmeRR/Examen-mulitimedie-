using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text score;
    public Text lives;
    public PlayerMovement player;
    public PrisonerExit exit;

    private string scoreFormat;
    private string livesFormat;

    void Start()
    {
        scoreFormat = score.text;
        livesFormat = lives.text;
    }

    void Update()
    {
        score.text = string.Format(scoreFormat, player.score);
        lives.text = string.Format(livesFormat, exit.health - exit.damage, exit.health);
    }
}
