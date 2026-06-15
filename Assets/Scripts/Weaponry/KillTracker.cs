using UnityEngine;
using UnityEngine.UIElements;

public class KillTracker : MonoBehaviour
{
    public static KillTracker instance;

	public int killsNeeded = 5;
	public int currentKills = 0;

	public Image missileFillBar;
	/*
	public void AddKill()
	{
		currentKills++;

		float progress = (float)currentKills / killsNeeded;
		missileFillBar.fillAmount = progress;

		if (progress >= 1f)
		{
			WeaponsManager.instance.UnlockWeapon(1); // missile ID
		}
	}*/
}
