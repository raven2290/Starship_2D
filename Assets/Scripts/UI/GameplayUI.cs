using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
	[Header("Bars")]
	public Image healthBar;
	public Image shieldBar;
	[Header("Text")]
	public TMP_Text scoreText;
	public TMP_Text livesText;
	[Header("Weapon Icons")]
	public Image bulletIcon;
	public Image missileIcon;
	public Image laserIcon;

	[Header("Weapon colors")]
	public Color selectedColor = Color.white;
	public Color unselectedColor = new Color(1, 1, 1, 0.3f);

	[Header("Select Weapons")]
	public float selectWeapons;

	int selectedWeapon = 1; // bullet = 1, missile = 2, laser = 3

	void Start()
	{
		UpdateWeaponIcons();
	}
	

	//-----------------------
	// health + shield bar
	//-----------------------
	public void UpdateHealth(float current, float max)
	{
		healthBar.fillAmount = current/max;
	}

	public void UpdateShield(float current, float max)
	{
		shieldBar.fillAmount = current/max;
	}

	//-----------------------
	// score + lives
	//-----------------------
	public void UpdateScore(int score)
	{
		scoreText.text = "Score: " + score;
	}

	public void UpdateLives(int lives)
	{
		livesText.text = " LIVES: " + lives;
	}

	//-----------------------
	// weapon selection
	//-----------------------

	public void HandleWeaponSwitch(int weaponID)
	{
		WeaponManager.instance.SelectWeapon(weaponID);
		GameManager.instance.SetWeapon(weaponID + 1);
	}

	public void UpdateWeaponIcons()
	{
		bulletIcon.color = (selectedWeapon == 1) ? selectedColor : unselectedColor;
		missileIcon.color = (selectedWeapon == 2) ? selectedColor : unselectedColor;
		laserIcon.color = (selectedWeapon == 3) ? selectedColor : unselectedColor;
	}

	public void SelectWeapon(int weaponID)
	{
		selectedWeapon = weaponID;
		UpdateWeaponIcons();
	}
}
