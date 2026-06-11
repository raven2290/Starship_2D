using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Pawn;

public class PlayerController : Controller
{
	public Pawn Pawn;

	[Header("Key Code Settings")]
	// movement keys
	public KeyCode forward1;
	public KeyCode forward2;
	public KeyCode backward1;
	public KeyCode backward2;
	public KeyCode clockwise1;
	public KeyCode clockwise2;
	public KeyCode counterclockwise1;
	public KeyCode counterclockwise2;
	// specialty keys
	public KeyCode Shoot;
	public KeyCode teleport;
	public KeyCode quit;
	public KeyCode turbo;
	public KeyCode turbo2;
	// weapon switch keys
	public KeyCode Weapon1;
	public KeyCode Weapon2;
	public KeyCode Weapon3;

	/*
	[Header("Controller Settings")]
	//movement inputs
	public ControlInput forward;
	public ControlInput backward;
	public ControlInput clockwise;
	public ControlInput counterclockwise;
	//specialty inputs
	public ControlInput fireInput;
	public ControlInput turboInput;
	public ControlInput quitInput;
	*/
	

	private void Start()
	{
		StarshipPawn starshipPawn = GetComponent<StarshipPawn>();
		Pawn = starshipPawn;
		if (Pawn.pawnType != PawnType.Player)
			Debug.LogWarning($"{name} has PlayerController but is not marked as Player Pawn!");
	}
	void Update()
    {
        if (Pawn == null) return;
		if(Pawn.pawnType != Pawn.PawnType.Player) return;

        HandleMovement();
		HandleRotation();
        HandleFiring();
        //HandleWeaponSwitch();
		HandleOtherEvents();
	}

	void HandleOtherEvents()
	{
		// quit game
		if (Input.GetKeyDown(quit))
		{
			Application.Quit();
			Debug.Log("Program is quitting");
		}	
		
		if (Input.GetKeyDown(teleport))
		{
			Pawn.Teleport();
			Debug.Log("Teleported");
		}


		//wait for 5 seconds before quitting to allow the log message to be seen and then quit the Editor if running in the editor
		//EditorApplication.isPlaying = false;
		// TODO: add pause menu toggle

	}

	void HandleMovement()
	{
		{
			if (Input.GetKey(turbo) || Input.GetKey(turbo2))
			{
				Pawn.Turbo();
				Debug.Log("Using turbo");
			}

			if (Input.GetKey(forward1) || Input.GetKey(forward2))
			{
				Pawn.MoveForward();
				Debug.Log("Moving forward");
			}

			if (Input.GetKey(backward1) || Input.GetKey(backward2))
			{
				Pawn.MoveBackward();
				Debug.Log("Moving backward");
			}
		}
	}
	void HandleRotation()
        {
			if (Input.GetKey(clockwise1) || Input.GetKey(clockwise2))
			{
				Pawn.RotateClockwise();
				Debug.Log("Rotating left");
			}

			if (Input.GetKey(counterclockwise1) || Input.GetKey(counterclockwise2))
            {
                Pawn.RotateCounterClockwise();
                Debug.Log("Rotating right");
            }
	}

	void HandleFiring()
	{

		if (Input.GetKey(Shoot))
		{
			Pawn.Shoot();
			Debug.Log("Firing weapon");
		}
	}


	void HandleWeaponSwitch()
	{
		if (Input.GetKeyDown(Weapon1))
		{
			WeaponManager.instance.SelectWeapon(0);
			GameManager.instance.SetWeapon(0);
		}

		if (Input.GetKeyDown(Weapon2))
		{
			WeaponManager.instance.SelectWeapon(1);
			GameManager.instance.SetWeapon(1);
		}

		if (Input.GetKeyDown(Weapon3))
		{
			WeaponManager.instance.SelectWeapon(2);
			GameManager.instance.SetWeapon(2);
		}
	}


	// TODO: add function for camera switching for 3D mode
}

