using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause Clicked");
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        Debug.Log("Resume Clicked");
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        Debug.Log("Main Menu Clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        Debug.Log("Settings Clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }


}
