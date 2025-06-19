using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
   public void PlayPressed()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayPressed2()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayPressed3()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit Pressed");
    }
}
