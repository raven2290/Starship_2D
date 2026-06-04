using System.Collections.Generic;
using Unity.VisualScripting;
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
	public GameObject AstroidPrefab;
    public GameObject EnemyStarShipPrefab;

    [Header("Game Data")]
    public float score;
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

    void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("spawned player: " + player.name);
        cameraFollow.SetTarget(player.transform);
        Debug.Log("Camera is following " + gameObject.name);
    }

    void SpawnEnemyStarship()
    {

    }

	void SpawnAstroid()
    {

    }
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
}
