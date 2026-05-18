using UnityEngine;

public class PlayerController : Controller
{
    public Pawn Pawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pawn != null)
        {
			// increase movement speed when left shift is held down
			if (Input.GetKey(KeyCode.LeftShift))
			    {
				    Pawn.Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * 2);
                    Debug.Log("increasing movement speed");
			}
			else
			    {
				    Pawn.Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
			    }

			// # up and down movement using W/S or Up/Down arrow keys
			if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow)) 
            {
                Pawn.Move(Pawn.transform.up);
                Debug.Log("moving forward");
			}
            else if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
            {
                Pawn.Move(-Pawn.transform.up);
                Debug.Log("moving backward");
            }

			//# rotation using A/D or Left/Right arrow keys
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				Pawn.Rotate(1.0f);
				Debug.Log("rotating left");
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				Pawn.Rotate(-1.0f);
				Debug.Log("rotating right");
			}

			//# fire weapon using spacebar or left mouse button

			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				Debug.Log("firing weapon");
			}

			//# switch between weapons using number keys 1-3
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Debug.Log("switching to weapon 1");
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Debug.Log("switching to weapon 2");
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Debug.Log("switching to weapon 3");
				//# for only weapon 3 holding down firing button will charge up a powerful shot
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
				{
					Debug.Log("charging weapon 3");
				}
			}

			

			
		}
	}
}
