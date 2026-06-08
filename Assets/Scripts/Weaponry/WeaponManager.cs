using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    public WeaponBase[] Weapons;
    public int currentWeapon = 0;

    public void SelectWeapon(int index)
    {
        currentWeapon = index;
        for (int i = 0; i < Weapons.Length; i++)
            Weapons[i].gameObject.SetActive(i == currentWeapon);    

    }
}
