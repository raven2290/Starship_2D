using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

	[Header("Spawn Points")]
    public Transform spawnPoint; // Spawn point for player
    public Transform spawnPointES; // Spawn Point for Enemy Starship
    public Transform spawnPointA; // Spawn Point for Astroids
    public Transform spawnPointM; // Spawns the Meteor
    
    [Header("Players")]
	public GameObject player;
	public GameObject enemyStarships;
	public GameObject astroid;

    [Header("World")]
    public GameObject meteor;

	[Header("Player Weapons")]
    public GameObject Bullet;
    public GameObject Missiles;
    public GameObject Laser;

	[Header("Prefabs")]
    public GameObject PlayerPawnPrefab;
	public GameObject PlayerControllerPrefab;

	[Header("Spawning")]
	public GameObject[] spawnPrefabs;
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
	
    
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}

    //------------
    // Player and Weapons
    //------------
    void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("spawned player: " + player.name);
        cameraFollow.SetTarget(player.transform);
        Debug.Log("Camera is following " + gameObject.name);
    }

	//------------
	// Enemies, Meteors, and Asteroids
	//------------
    public void RemoveSpawn(GameObject obj)
    {
        activeSpawns.Remove(obj);
    }

	private IEnumerator SpawnLoop()
	{
		while (GamePlayStateObject.activeSelf)
		{
			activeSpawns.RemoveAll(item => item == null);
			if (activeSpawns.Count < maxSpawn)
			{
				SpawnRandomObject();
			}
			yield return new WaitForSeconds(spawnIntervals);
		}
	}

	private void SpawnRandomObject()
	{
		GameObject prefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];

		Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
		Vector3 spawnPos = new Vector3(randomPos.x, randomPos.y, 0f);

		GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);
		activeSpawns.Add(obj);
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
