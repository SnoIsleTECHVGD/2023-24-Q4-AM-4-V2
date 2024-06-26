using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public GameObject player, cam;
    public float buildup = 1, jumpheight = 1, maxspeed = 1;

    private Rigidbody2D rb2D;
    private BoxCollider2D b2D;
    private SpriteRenderer spriteRenderer;
    public bool WASD = true;
    public bool WASDon = false;
    public LayerMask groundLayer;
    public float jumpbool;
    private float boxCastFloat = 0.51f;
    private bool grounded()
    {
        return Physics2D.BoxCast(transform.position - new Vector3(0f, boxCastFloat), new Vector2(jumpbool / 3, jumpbool), 0, Vector2.zero, 1, groundLayer);
    }
    private bool jumpHeld;
    private float timeSinceJump = -5;
    float cooldown = 0.2f;
    private float xVelocity;
    private float camAndPlayDist;
    private float camPos;
    private bool antiGravity = false;
    private bool fhq = false;
    private bool qhf = true;
    private float aGravFloat = 1f;
    private float aGravFloat2 = 1f;
    public float deltaTime, timebool;

    float inputHorizontal;
    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        b2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        deltaTime = Time.deltaTime * timebool;
        if (antiGravity)
        {
            rb2D.gravityScale = -rb2D.gravityScale;
            antiGravity = !antiGravity;
            fhq = !fhq;
        }
        //rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rb2D.velocity.y);

        if (rb2D.velocity.x != 0f)
        {
            spriteRenderer.flipX = rb2D.velocity.x < 0f;
        }

        if (WASD == false)
        {
            if (Input.GetKey(left))
            {
                rb2D.AddForce(Vector2.left * buildup * deltaTime);
                GetComponent<Animator>().SetInteger("State", 1);
            }
            else if (Input.GetKey(right))
            {
                rb2D.AddForce(Vector2.right * buildup * deltaTime);
                GetComponent<Animator>().SetInteger("State", 1);
            }
            else
            {
                GetComponent<Animator>().SetInteger("State", 0);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Babies");
                rb2D.AddForce(Vector2.left * buildup * deltaTime);
                GetComponent<Animator>().SetInteger("State", 2);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb2D.AddForce(Vector2.right * buildup * deltaTime);
                GetComponent<Animator>().SetInteger("State", 1);

            }
            else
            {
                GetComponent<Animator>().SetInteger("State", 0);
            }
        }

        if (grounded() && Input.GetKeyDown(jump) || (Time.time - cooldown < timeSinceJump && grounded()))
        {

            xVelocity = rb2D.velocity.x;
            rb2D.velocity = new Vector3(xVelocity, jumpheight, 0);
            cooldown = 0f;

        }
              
        // Control jump height with length of jump held
        if (Input.GetKey(jump))
        {
            jumpHeld = true;
            if (jumpHeld == true)
            {

                GetComponent<Animator>().SetInteger("State", 3);
            }
            else
            {
                GetComponent<Animator>().SetInteger("State", 0);
            }
        }
        else { jumpHeld = false; }


        if ((player.GetComponent<PlayerStats>().hasEatenAGFruit == false && !jumpHeld && !grounded() && rb2D.velocity.y > 0 && !fhq) || (player.GetComponent<PlayerStats>().hasEatenAGFruit == true && !jumpHeld && !grounded() && rb2D.velocity.y < 0 && fhq))
        {
            xVelocity = rb2D.velocity.x;
            rb2D.velocity = new Vector3(xVelocity, 0, 0);
        }

        if (Input.GetKeyDown(jump) && !grounded())
        {
            timeSinceJump = Time.time;
            cooldown = 0.2f;
        }
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed), rb2D.velocity.y);
        // Anti-Gravity Fruit functionality

        if ((player.GetComponent<PlayerStats>().hasEatenAGFruit == true && qhf == true) || aGravFloat % 2 == 0)
        {
            Debug.Log("jh");
            camAndPlayDist = cam.transform.position.x - player.transform.position.x;
            cam.transform.Rotate(0f, 0f, 180f);
            player.transform.Rotate(0f, 0f, 180f);
            camPos = cam.transform.position.x + (2 * camAndPlayDist);
            cam.transform.position += new Vector3(2 * camAndPlayDist, 0, 0);
            boxCastFloat = -boxCastFloat;
            antiGravity = !antiGravity;
            jumpheight = -jumpheight;
            qhf = false;
            aGravFloat2 += 1;
        }
        if (aGravFloat2 % 2 == 0 && player.GetComponent<PlayerStats>().fruitTimer == 0f)
        {
            qhf = true;
            aGravFloat += 1;
            aGravFloat2 += 1;
        }
        if (aGravFloat >= 3)
        {
            aGravFloat = 1;
            aGravFloat2 = 1;
        }
    }
    void WASDswap()
    {
        WASDon = WASD;
        WASDon = !WASDon;
        WASD = WASDon;
    }
}