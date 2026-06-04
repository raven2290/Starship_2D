using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void GamePlay()
    {
        GameManager.instance.ActivateGamePlayStateObject();

	}

    public void OpenCredits()
    {
        GameManager.instance.ActivateCreditStateObject();

	}

    public void OpenOptions()
    {
        GameManager.instance.ActivateOptionsStateObject();

	}

    public void QuitGame()
    {
		GameManager.instance.QuitGame();
	}
}
