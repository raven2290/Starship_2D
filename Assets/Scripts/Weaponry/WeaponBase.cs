using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public abstract void FireDown(); //when button is pressed
    public abstract void FireHeld(); //while button is held
	public abstract void FireUp(); //when button is released
}
