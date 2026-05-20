using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : Controller
{
    public Pawn Pawn;
 

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
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
			Debug.Log("Program is quitting");
		//wait for 5 seconds before quitting to allow the log message to be seen and then quit the Editor if running in the editor
			//EditorApplication.isPlaying = false;
		// TODO: add pause menu toggle

	}

	void HandleMovement()
        { 
            float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                Pawn.Move(Pawn.transform.up * speedMultiplier);
				Debug.Log("Moving forward");

			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                Pawn.Move(-Pawn.transform.up * speedMultiplier);
				Debug.Log("Moving backward");
		}
	void HandleRotation()
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			    Pawn.Rotate(1f);
				Debug.Log("Rotating left");

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                Pawn.Rotate(-1f);
				Debug.Log("Rotating right");
	    }

	
	void HandleWeaponSwitch()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			WeaponManager.instance.SwitchWeapon(0);
		if (Input.GetKeyDown(KeyCode.Alpha2))
			WeaponManager.instance.SwitchWeapon(1);
		if (Input.GetKeyDown(KeyCode.Alpha3))
			WeaponManager.instance.SwitchWeapon(2);
	}

	void HandleFiring()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			WeaponManager.instance.FireDown();
		if (Input.GetKey(KeyCode.Space))
			WeaponManager.instance.FireHeld();
		if (Input.GetKeyUp(KeyCode.Space))
			WeaponManager.instance.FireUp();
		// TODO: add damage dealing and visual effects for firing
	}

	// TODO: add function for camera switching for 3D mode
}

