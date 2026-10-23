using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialText;
    void Update()
    {
        TutorialText.SetActive(Globals.IsTutorial);
    }
}
