using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialText;
    void Update()
    {
        if(Globals.IsTutorial == true)
        {
            TutorialText.SetActive(true);
        }

        if(Globals.IsTutorial == false)
        {
            TutorialText.SetActive(false);
        }
    }
}
