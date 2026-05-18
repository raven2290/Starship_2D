using UnityEngine;

public class SpriteRendering : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
	public Pawn Pawn;
    public Enemy Enemy;
    public Astroid Astroid;
    public Color PawnColor;
    public Color EnemyColor;
	public Color AstroidColor;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer == null) 
        {
            Debug.LogError("SpriteRenderer not found!");
        }
        else
        {
            spriteRenderer.color = PawnColor;
            spriteRenderer.color = EnemyColor;
            spriteRenderer.color = AstroidColor;
		}
		// Set the color of the sprite based on the type of object
	}
}
