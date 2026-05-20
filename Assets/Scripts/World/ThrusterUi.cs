using UnityEngine;

public class ThrusterUi : MonoBehaviour
{
    //public Rigidbody rb;
    public ParticleSystem Thruster;
    private ParticleSystem.EmissionModule em;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        em = Thruster.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
		{
			em.rateOverTime = 40f; //strong thruster effect when moving forward
		}
		else
		{
			em.rateOverTime = 5f; // idle thruster effect when not moving forward
		}

        /*
        // add velocity to the thruster particles based on the player's movement speed
        float speed = rb.velocity.magnitude;
        em.rateOverTime = Mathf.Lerp(5f, 50f, speed / maxSpeed);*/
	}
}
