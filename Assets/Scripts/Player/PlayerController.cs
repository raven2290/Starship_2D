using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

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
	public KeyCode fire;
	public KeyCode teleport;
	public KeyCode quit;
	public KeyCode turbo;
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

	// Update is called once per frame
	void Update()
    {
        if (Pawn == null) return;
        HandleMovement();
		HandleRotation();
        HandleFiring();
        HandleWeaponSwitch();
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
            float speedMultiplier = Input.GetKey(turbo) ? 2f : 1f;

            if(Input.GetKey(forward1) || Input.GetKey(forward2))
                Pawn.MoveForward();
				Debug.Log("Moving forward");

			if (Input.GetKey(backward1) || Input.GetKey(backward2))
                Pawn.MoveBackward();
				Debug.Log("Moving backward");
		}
	void HandleRotation()
        {
            if(Input.GetKey(clockwise1) || Input.GetKey(clockwise2))
			    Pawn.RotateClockwise();
				Debug.Log("Rotating left");

			if (Input.GetKey(counterclockwise1) || Input.GetKey(counterclockwise2))
                Pawn.RotateCounterClockwise();
				Debug.Log("Rotating right");
	    }

	
	void HandleWeaponSwitch()
	{
		if (Input.GetKeyDown(Weapon1))
			WeaponManager.instance.SwitchWeapon(0);
		if (Input.GetKeyDown(Weapon2))
			WeaponManager.instance.SwitchWeapon(1);
		if (Input.GetKeyDown(Weapon3))
			WeaponManager.instance.SwitchWeapon(2);
	}

	void HandleFiring()
	{
		if (Input.GetKeyDown(fire))
			WeaponManager.instance.FireDown();
		if (Input.GetKey(fire))
			WeaponManager.instance.FireHeld();
		if (Input.GetKeyUp(fire))
			WeaponManager.instance.FireUp();
		// TODO: add damage dealing and visual effects for firing
	}

	// TODO: add function for camera switching for 3D mode
}

