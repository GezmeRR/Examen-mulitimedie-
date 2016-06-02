using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UILoadScene : UIBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void GoToNext()
    {
        GoTo(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToPrevius()
    {
        GoTo(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoTo(int id)
    {
        SceneManager.LoadScene(id);
    }
}
