using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

	[Header("Spawn Points")]
	public Transform spawnPoint; // spawn point for player
    
    [Header("Players")]
	public GameObject player;
	public GameObject enemyStarships;
	public GameObject astroid;

    [Header("World")]
    public GameObject meteor; // 10x10 world object

	[Header("Player Weapons")]
    public GameObject Bullet;
    public GameObject Missiles;
    public GameObject Laser;

	[Header("Prefabs")]
    public GameObject PlayerPawnPrefab;
	public GameObject PlayerControllerPrefab;

	[Header("Spawning")]
	public GameObject[] spawnPrefabs; // enemy ships + asteroids
    public int maxSpawn;
    public float spawnRadius;
    public float spawnIntervals;

    private List<GameObject> activeSpawns = new List<GameObject>();

    [Header("Game Data")]
    public int score;
    public float highScore;
    public int maxLives;
    public int currentLives;
    public CameraController cameraFollow;

    [Header("Game State")]
    public GameObject TitleStateObject;
    public GameObject MainMenuStateObject;
    public GameObject GamePlayStateObject;
    public GameObject OptionsStateObject;
	public GameObject CreditStateObject;
    public GameObject GameOverStateObject;

    [Header("Audio Clips")]
    public AudioClip bulletSFX;
    public AudioClip missileSFX;
    public AudioClip laserSFX;

    [Header("UI")]
    public GameplayUI gameplayUI;
	


	public List<DamageOnCollision> damageOnCollision = new List<DamageOnCollision>();


	public void Awake()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
        else
        {
            instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}



	//------------
	// Player and Weapons
	//------------
	public void SpawnPlayer()
	{
		GameObject newPlayer = Instantiate(PlayerPawnPrefab, spawnPoint.position, Quaternion.identity);

		CameraController cam = Camera.main.GetComponent<CameraController>();
		cam.SetTarget(newPlayer.transform);
	}

	//------------
	// spawn assistance
	//------------

	private Vector3 GetSpawnPosition(float minDistance, float maxDistance)
	{
		if (player==null) return Vector3.zero;

		Vector2 dir = Random.insideUnitCircle.normalized;
		float dist = Random.Range(minDistance, maxDistance);

		return player.transform.position + new Vector3(dir.x, dir.y, 0f) * dist;
	}

	// check if position is clear for meteor placement
	private bool IsPositionClear(Vector3 position, float radius)
	{
		foreach(GameObject obj in activeSpawns)
		{
			if (obj == null) continue;
			if (Vector3.Distance(obj.transform.position, position) < radius)
				return false;
		}
		return true;
	}

	//------------
	// Enemies, Meteors, and Asteroids
	//------------
	
	// spawn enemy ships or asteroids
	private void SpawnEnemyOrAsteroid()
	{
		GameObject prefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];

		float minDist = 10f;
		float maxDist = 50f;

		Vector3 spawnPos = GetSpawnPosition(minDist, maxDist);

		GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);
			activeSpawns.Add(obj);
	}

	//spawn meteor 
	private void SpawnMeteor()
	{
		float minDist = 30f;
		float maxDist = 100f;
		float meteorRadius = 12f; // safe space for object

		Vector3 spawnPos;
		int attempts = 0;

		do
		{
			spawnPos = GetSpawnPosition(minDist, maxDist);
			attempts++;
		}
		while (!IsPositionClear(spawnPos, meteorRadius) && attempts < 20);

		GameObject obj = Instantiate(meteor, spawnPos, Quaternion.identity);
		activeSpawns.Add(obj);
	}

	private IEnumerator SpawnLoop()
	{
		while (GamePlayStateObject.activeSelf)
		{
			activeSpawns.RemoveAll(item => item == null);

			if (activeSpawns.Count < maxSpawn)
			{
				if (Random.value < 0.10f) // 10% chance meteor
					SpawnMeteor();
				else
					SpawnEnemyOrAsteroid();
			}

			yield return new WaitForSeconds(spawnIntervals);
		}
	}

	//------------
	// Game States
	//------------
	private void DeActivateAllStates()
    {
        // deactivate all Game States
        TitleStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
	    GamePlayStateObject.SetActive(false);
	    OptionsStateObject.SetActive(false);
	    CreditStateObject.SetActive(false);
		GameOverStateObject.SetActive(false);

	}

    public void ActivateTitleStateObject()
    {
        //deactivate all game states
        DeActivateAllStates();
        // activate title screen
		TitleStateObject.SetActive(true);
    }

	public void ActivateMainMenuStateObject()
	{
		//deactivate all game states
		DeActivateAllStates();
		// activate Main Menu screen
		MainMenuStateObject.SetActive(true);
	}

    public void ActivateOptionsStateObject()
    {
		//deactivate all game states
		DeActivateAllStates();
		// activate options screen
		OptionsStateObject.SetActive(true);
	}

    public void ActivateGamePlayStateObject()
    {
		// deactivate all game states
		DeActivateAllStates();
        //activate Game play screen
        GamePlayStateObject.SetActive(true);
        SpawnPlayer();
		StartCoroutine(SpawnLoop());

	}

    public void ActivateCreditStateObject()
    {
		// deactivate all game states
		DeActivateAllStates();
        CreditStateObject.SetActive(true);
	}

    public void ActivateGameOverStateObject()
    {
        DeActivateAllStates();
		GameOverStateObject.SetActive(true);
	}

    public void QuitGame()
    {
        Application.Quit();
    }


	//------------
	// Player UI
	//------------
	public void UpdatePlayerHealth(float current, float max)
    {
        gameplayUI.UpdateHealth(current, max);
    }

    public void UpdatePlayerShield(float current, float max)
    {
        gameplayUI.UpdateShield(current, max);
    }

	public void AddScore(int amount)
	{
		score += amount;
		gameplayUI.UpdateScore(score);
	}

	public void UpdateLives(int lives)
    {
        gameplayUI.UpdateLives(lives);
    }

	//------------
	// Audio UI
	//------------

    public void PlayBullet()
    {
        AudioManager.instance.PlaySFX(bulletSFX);
    }

	public void PlayMissile()
	{
		AudioManager.instance.PlaySFX(missileSFX);
	}

	public void PlayLaser()
	{
		AudioManager.instance.PlaySFX(laserSFX);
	}

	//------------
	// Weapons
	//------------

	public void SetWeapon(int weaponID)
	{
        WeaponManager.instance.SelectWeapon(weaponID);
        gameplayUI.SelectWeapon(weaponID + 1);
        AudioManager.instance.PlaySFX(GetWeaponSFX(weaponID));
	}

	private AudioClip GetWeaponSFX(int weaponID)
	{
		switch (weaponID)
		{
			case 0: return bulletSFX;
			case 1: return missileSFX;
			case 2: return laserSFX;
			default: return null;
		}
	}
}
