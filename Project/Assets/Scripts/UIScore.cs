using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIScore : UIBehaviour
{
    private Text text;
    private string format;

    void Start()
    {
        text = GetComponent<Text>();
        format = text.text;
    }

    void Update()
    {
        text.text = string.Format(format, SaveFile.newScore);
    }
}
