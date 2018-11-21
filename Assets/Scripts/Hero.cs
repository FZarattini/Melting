using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float velocityX;

    private Vector2 translation;

    private Rigidbody2D rb;

    private SpriteRenderer heroSR;

    //private float deltaX;

    private bool isOnTile;

    private int direction;

    private bool firstMove;

    [SerializeField]
    private Sprite[] sprites;

    Animator animator;
 
    private bool alreadyDecreasedFirst;
    private bool alreadyDecreasedSecond;

    [SerializeField]
    private float oppositePunch;
    //Used to know if the next direction is the opposite to the current direction
    private int lastSign;

    //Point Pickup Logic
    private bool collided;
    //Heal Pickup Logic
    private bool healCollided;
    //Speed Up Pickup Logic
    private bool speedUpCollided;

    private Vector2 initialSize;
    
    public Life life;
    
    // Use this for initialization
    void Start()
    {
        firstMove = true;
        collided = false;
        healCollided = false;
        speedUpCollided = false;
        heroSR = gameObject.GetComponent<SpriteRenderer>();
        //animator.SetBool("Damaged", false);
        //animator.SetBool("Moving", false);

        alreadyDecreasedFirst = false;
        animator = gameObject.GetComponent<Animator>();
        isOnTile = false;
        //deltaX = 2f;
        translation = new Vector2(0f, 0f);
        transform.position = new Vector2(0f, 0f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        initialSize = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
        //GetComponent<Rigidbody2D>().drag = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        Tp(direction);

        if (!isOnTile)
        {
            animator.SetBool("Damaged", true);
        }
        else
        {
            animator.SetBool("Damaged", false);
        }

        if (rb.velocity.x > 1.15f || rb.velocity.x < -1.15f)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetTrigger("EndMovement");
        }
    }

    public void Move(int sign, float doubleTap, float timerLongTap)
    {

        if (sign < 0)
        {
            heroSR.flipX = true;
        }
        else {
            heroSR.flipX = false;
        }
        

        if (rb != null)
        {
            if (lastSign == sign)
            {
                if (timerLongTap > 0f)
                {
                    rb.AddForce(new Vector2(sign * doubleTap * (timerLongTap * 5f) *
                                            Mathf.SmoothDamp(50f, 0f, ref velocityX, Time.deltaTime), 0f));
                }
                else
                {
                    rb.AddForce(new Vector2(sign * doubleTap * Mathf.SmoothDamp(50f, 0f, ref velocityX, Time.deltaTime), 0f));
                    animator.SetTrigger("BeginMovement");
                }
                direction = sign;
            }
            else
            {
                Debug.Log("Different Sign! : " + lastSign + " != " + sign);
                if (timerLongTap > 0f)
                {
                    rb.AddForce(new Vector2(sign * doubleTap * (timerLongTap * 5f) * (oppositePunch * 4), 0f));


                }
                else
                {
                    rb.AddForce(new Vector2(sign * doubleTap, 0f) * oppositePunch);
                    animator.SetTrigger("BeginMovement");
                }
            }
        }

        lastSign = sign;
        //translation.x += doubleTap * velocityX * sign;
        //translation.x *= Time.deltaTime;
        //transform.Translate(translation);

    }

    public void Tp(int sign) {
        if (transform.position.x > 4.25f && sign > 0)
        {
            rb.position = new Vector3(-4.5f, 0f, 0f);
            //transform.position = new Vector3(-4.5f, 0f, 0f);
        }
        else if(transform.position.x < -4.25f && sign < 0)
        {
            transform.position = new Vector3(4.5f, 0f, 0f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            isOnTile = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            isOnTile = false;

        }
    }

    public bool PlayerIsOnTile() {
        return isOnTile;
    }
    
    public void UpdateSize()
    {
        float ratio = life.lifePoints / life.maxLifePoints;
        //Debug.Log(ratio);
        Vector2 newScale = new Vector2(ratio * initialSize.x, ratio * initialSize.y);
        gameObject.transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            collided = true;

            Destroy(collision.gameObject);
        }
        if(collision.tag == "Heal")
        {
            healCollided = true;

            Destroy(collision.gameObject);
        }
        if(collision.tag == "SpeedUp")
        {
            speedUpCollided = true;

            Destroy(collision.gameObject);
        }
    }

    public bool HasCollidedWithPoint()
    {
        return collided;
    }

    public void UpdateCollidedWithPoint(bool collided)
    {
        this.collided = collided;
    }

    public bool HasCollidedWithHeal()
    {
        UpdateSize();

        return healCollided;
    }

    public void UpdateCollidedWithHeal(bool collided)
    {
        this.healCollided = collided;
    }
   
    public bool HasCollidedWithSpeedUp()
    {
        return speedUpCollided;
    }

    public void UpdateCollidedWithSpeedUp(bool collided)
    {
        this.speedUpCollided = collided;
    }
}
