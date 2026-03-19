using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    
    private SpriteRenderer spriteRenderer; // private variables are lowercase
    private bool isDrunk = false;
    private bool isPlastered = false;
    private Coroutine soberupCoroutine;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                Move(new Vector2(1, 0)); //right
                break;
            case 1:
                Move(new Vector2(-1, 0)); //left
                break;
            case 2:
                Move(new Vector2(0, 1)); //up
                break;
            case 3:
                Move(new Vector2(0, -1)); //down
                break;
        }
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        FaceCorrectDirection(direction);
        
        // make corgi move
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime; // deltaTime accounts for refresh rate 
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0f);   // Translate will move on x and y axis

        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }
        return direction;
    }

    //public void OnCollisionEnter2D(Collision2D other)
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bone")
        {
            print("bone things");
        }
        else if (other.tag == "Pill")
        {
            print("pill things");
        }
    }

    public void OnCollisionEnter2D(Collision2D other)   //moonshine doesnt have a trigger 
    {
        if (other.collider.tag == "Moonshine")
        {
            Destroy(other.gameObject);
            GetPlastered();
        }
    }

    private void GetPlastered()
    {
        isPlastered = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
        
    }

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
        
    }

    private void StartSoberingUp()
    {
        if (soberupCoroutine != null)
            StopCoroutine(soberupCoroutine);
            
        soberupCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        ChangeToSoberSprite();
        isDrunk = false;
        isPlastered = false;
    }

    private void ChangeToSoberSprite()
    {
        spriteRenderer.sprite = SoberSprite;
    }

    private void ChangeToDrunkSprite()
    {
        spriteRenderer.sprite = DrunkSprite;
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

    public Vector3 GetPosition()
    {
        return spriteRenderer.transform.position;
    }
}
