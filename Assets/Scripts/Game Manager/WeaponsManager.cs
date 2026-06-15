using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
	public static WeaponsManager instance;

	[Header("Weapons")]
	public GameObject[] weapons;   // 0 = Bullet, 1 = Missile, 2 = Laser
	public bool[] unlocked;        // same size as weapons[]

	public int currentWeapon = 0;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		// Initialize unlock array
		unlocked = new bool[weapons.Length];
		unlocked[0] = true; // bullets always unlocked
	}

	// Switch weapon
	public void SelectWeapon(int weaponID)
	{
		if (weaponID < 0 || weaponID >= weapons.Length)
			return;

		if (!unlocked[weaponID])
		{
			Debug.Log("Weapon not unlocked yet");
			return;
		}

		currentWeapon = weaponID;
		Debug.Log("Selected weapon: " + weapons[weaponID].name);
	}

	// Unlock a weapon
	public void UnlockWeapon(int weaponID)
	{
		if (weaponID < 0 || weaponID >= weapons.Length)
			return;

		unlocked[weaponID] = true;
		Debug.Log("Unlocked weapon: " + weapons[weaponID].name);
	}

	// Get the prefab for Shooter
	public GameObject GetCurrentWeaponPrefab()
	{
		return weapons[currentWeapon];
	}
}
