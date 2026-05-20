using UnityEngine;

public class DestructionTracker : MonoBehaviour
{
	public static DestructionTracker Instance;

	public int kills = 0;
	public int killsRequiredForMissiles;

	void Awake()
	{
		Instance = this;
	}

	public void AddKill()
	{
		kills++;
		if (kills >= killsRequiredForMissiles)
		{
			// unlock missiles for the player
			Debug.Log("Missiles Unlocked!");
		}
	}

	public bool MissilesUnlocked()
	{
		return kills >= killsRequiredForMissiles;
	}
}
