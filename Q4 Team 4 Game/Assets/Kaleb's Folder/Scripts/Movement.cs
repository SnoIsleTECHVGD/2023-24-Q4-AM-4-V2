using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public float buildup = 1, jumpheight = 1, maxspeed = 1;
    private Rigidbody2D rb2D;
    public bool WASD = false;
    public LayerMask groundLayer;
    public float jumpbool;
    private bool grounded => Physics2D.BoxCast(transform.position - new Vector3(0f, 0.51f), new Vector2(jumpbool, jumpbool), 0, Vector2.zero, 1, groundLayer);
    private bool jumpHeld;
    private float timeSinceJump = -5;
    float cooldown = 0.2f;
    private float xVelocity;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (WASD == false)
        {
            if (Input.GetKey(left))
            {
                rb2D.AddForce(Vector2.left * buildup);
            }

            if (Input.GetKey(right))
            {
                rb2D.AddForce(Vector2.right * buildup);
            }
        }
        else if (WASD == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb2D.AddForce(Vector2.left * buildup);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb2D.AddForce(Vector2.right * buildup);
            }
        }

        if (grounded && Input.GetKeyDown(jump) || (Time.time - cooldown < timeSinceJump && grounded))
        {
            xVelocity = rb2D.velocity.x;
            rb2D.velocity = new Vector3(xVelocity, jumpheight, 0);
        }

        // Control jump height with length of jump held
        if (Input.GetKey(jump))
        {
            jumpHeld = true;
        }
        else { jumpHeld = false; }


        if (!jumpHeld && !grounded && rb2D.velocity.y > 0)
        {
            xVelocity = rb2D.velocity.x;
            rb2D.velocity = new Vector3(xVelocity, 0, 0);
        }

        if (Input.GetKeyDown(jump) && !grounded)
        {
            timeSinceJump = Time.time;
        }
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed), rb2D.velocity.y);
    }
    public void WASDswap(bool WASDon)
    {
        WASD = WASDon;
        WASDon = !WASDon;
    }
}