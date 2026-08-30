using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject CredMenu;
    
    public void OnQuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnQuitMenu()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    public void OnOpenCred()
    {
        CredMenu.SetActive(true);
    }

    public void OnCloseCred()
    {
        CredMenu.SetActive(false);
    }
}
