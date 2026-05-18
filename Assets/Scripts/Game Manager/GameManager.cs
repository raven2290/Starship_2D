using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

	[Header("Player")]
    public List<PlayerController> players;

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
	//public List<Transform> AstroidSpawnPoints; // List of spawn points for the astroid
	//public List<Transform> EnemySpawnPoints; // List of spawn points for the enemy starship


	public void Awake()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
        else
        {
            instance = this;
        }
	}
	
    
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
