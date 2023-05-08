using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;

    public float walkSpeed;
    public float frameRate;
    float idleTime;

    public Joystick joystick;

    [HideInInspector]
    public Vector2 movement;

    [HideInInspector]
    public float lastHorizontalMove;

    [HideInInspector]
    public float lastVerticalMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get direction of input.
        movement = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;

        //move based on direction.
        rb.velocity = movement * walkSpeed;

        //make it face to each direction.
        handleSpriteFlip();

        List<Sprite> directionSprite = getSpriteDirection();

        if(directionSprite != null)
        {
            float playTime = Time.time - idleTime;
            int totalFrame = (int)(playTime * frameRate);
            int frame = totalFrame % directionSprite.Count;

            spriteRenderer.sprite = directionSprite[frame];
        } else

        {
            idleTime = Time.time;
        }

        if(movement.x != 0)
        {
            lastHorizontalMove = movement.x;
        }
        if(movement.y != 0)
        {
            lastVerticalMove = movement.y;
        }

    }

    void handleSpriteFlip()
    {
        if(!spriteRenderer.flipX && movement.x < 0) //left
        {
            spriteRenderer.flipX = true;
        } else
        
        if(spriteRenderer.flipX && movement.x > 0) //right
        {
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> getSpriteDirection()
    {
        List<Sprite> selectedSprite = null;

        if(movement.y > 0) //up
        {
            if(Mathf.Abs(movement.x) > 0) //e pr w
            {
                selectedSprite = neSprites;
            } else //neutral x
            
            {
                selectedSprite = nSprites;
            }
        } else

        if(movement.y < 0) //down
        {
            if(Mathf.Abs(movement.x) > 0) //e pr w
            {
                selectedSprite = seSprites;
            } else //neutral x
            
            {
                selectedSprite = sSprites;
            }
        } else //neutral

        {
            if(Mathf.Abs(movement.x) > 0) //e pr w
            {
                selectedSprite = eSprites;
            }
        }

        return selectedSprite;
    }
}
