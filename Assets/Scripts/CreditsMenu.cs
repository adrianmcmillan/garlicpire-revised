using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    
    public void MainMenuButton()
    {
        LevelManager.LoadLevel(Levels.MainMenu);
    }

}
