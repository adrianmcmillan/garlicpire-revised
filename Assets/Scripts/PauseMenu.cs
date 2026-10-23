using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject settings;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (container.activeInHierarchy)
            {
                this.CloseAllMenusIfOpen();
                Time.timeScale = 1;
            } else
            {
                container.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void SettingsButton()
    {
        container.SetActive(false);
        settings.SetActive(true);
    }

    public void leaveMenu()
    {
        Globals.Save();
        settings.SetActive(false);
        container.SetActive(true);
    }

    private void CloseAllMenusIfOpen()
    {
        container.SetActive(false);
        settings.SetActive(false);
    }


}
