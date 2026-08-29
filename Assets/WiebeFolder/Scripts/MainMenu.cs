using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnQuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitMenu()
    {
        Application.Quit();
    }
}
