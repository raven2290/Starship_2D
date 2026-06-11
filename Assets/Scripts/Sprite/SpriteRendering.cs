using UnityEngine;

public class SpriteRendering : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	public Pawn Pawn;
	public Enemy Enemy;
	//public Astroid Astroid;
	public Color PawnColor;
	public Color EnemyColor;
	//public Color AstroidColor;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if (spriteRenderer != null)
		
		{
			HandleSpriteColorPawn();
			//HandleSpriteColorAstroid();
			HandleSpriteColorEnemy();

			//spriteRenderer.color = PawnColor;
			//spriteRenderer.color = EnemyColor;
			//spriteRenderer.color = AstroidColor;
		}

		

		//fluctuate the color from green to turquoise and back to red over time using a sine wave for the player when shield is active


	}
	void HandleSpriteColorPawn()
	{
		// check if the player has a shield active
		if (Pawn != null && Pawn.GetComponent<StarshipPawn>() != null)
		{
			StarshipPawn starshipPawn = Pawn.GetComponent<StarshipPawn>();
			// create a shield script to change moveSpeed to shieldHealth
			if (starshipPawn != null) // assuming moveSpeed > 5 indicates shield is active
			{
				float t = (Mathf.Sin(Time.time) + 1) / 2; // t will oscillate between 0 and 1
				spriteRenderer.color = Color.Lerp(Color.green, Color.cyan, t);
			}
		}
	}
	/*
	void HandleSpriteColorAstroid()
	{
		// check if the player has a shield active
		if (Pawn != null && Pawn.GetComponent<StarshipPawn>() != null)
		{
			StarshipPawn starshipPawn = Pawn.GetComponent<StarshipPawn>();
			// create a shield script to change moveSpeed to shieldHealth
			if (starshipPawn != null && starshipPawn.moveSpeed > 5) // assuming moveSpeed > 5 indicates shield is active
			{
				float t = (Mathf.Sin(Time.time) + 1) / 2; // t will oscillate between 0 and 1
				spriteRenderer.color = Color.Lerp(Color.red, Color.darkTurquoise, t);
			}
		}
	}
	*/
	void HandleSpriteColorEnemy()
	{
		// check if the player has a shield active
		if (Enemy != null && Enemy.GetComponent<EnemyStarship>() != null)
		{
			EnemyStarship enemyStarship = Enemy.GetComponent<EnemyStarship>();
			// create a shield script to change moveSpeed to shieldHealth
			if (enemyStarship != null) // assuming moveSpeed > 5 indicates shield is active
			{
				float t = (Mathf.Sin(Time.time) + 1) / 2; // t will oscillate between 0 and 1
				spriteRenderer.color = Color.Lerp(Color.red, Color.purple, t);
			}
		}
	} 
}
