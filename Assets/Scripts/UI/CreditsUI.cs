using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    public void BackToTheMenu()
    {
		GameManager.instance.ActivateMainMenuStateObject();
	}
}
