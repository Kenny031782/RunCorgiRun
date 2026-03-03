using UnityEngine;

public class Corgi : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // private variables are lowercase

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        
        // make corgi move
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime; // deltaTime accounts for refresh rate 
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0f);   // Translate will move on x and y axis
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
