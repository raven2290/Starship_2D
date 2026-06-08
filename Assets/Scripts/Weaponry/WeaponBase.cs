using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public string weaponName;
    public float fireRate;
    protected float nextFireTime;

    public abstract void Fire();
}
