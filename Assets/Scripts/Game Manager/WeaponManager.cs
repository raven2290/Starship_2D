using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    public WeaponBase[] weapons;
    private int currentWeapon = 0;

	private void Awake()
	{
		instance = this;
	}

	public void SwitchWeapon(int Index)
	{
		currentWeapon = Index;
		Debug.Log("Switched to weapon: " + weapons[currentWeapon].name);
	}

	public void FireDown()
	{ 
		weapons[currentWeapon].FireDown();
	}

	public void FireHeld()
	{
		weapons[currentWeapon].FireHeld();
	}

	public void FireUp()
	{
		weapons[currentWeapon].FireUp();
	}

}
