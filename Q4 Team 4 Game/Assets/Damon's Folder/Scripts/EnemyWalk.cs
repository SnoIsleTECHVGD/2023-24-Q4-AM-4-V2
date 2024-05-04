using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    Rigidbody2D myRigidbody;

    float inputHorizontal;

    public GameObject player;
    private float distance;
    private Vector2 direction;
    public float minDistance = 30f;
    public float maxDistance = 45f;
    bool isChasing;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
    if (IsFacingRight())
        {
            GetComponent<Animator>().SetInteger("State", 1);
            myRigidbody.velocity = new Vector2(speed, 0f);
        }  
        else if (!IsFacingRight())
        {
            GetComponent<Animator>().SetInteger("State", 2);
            myRigidbody.velocity = new Vector2(-speed, 0f);
        }
    else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }
    */
        distance = Vector2.Distance(transform.position, player.transform.position);
         direction = player.transform.position - transform.position;
        if (distance < minDistance)
        {
            isChasing = true;
        }
        if(distance > maxDistance)
        {
            isChasing = false;
        }
        
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
       
        

        if (!IsFacingRight() && isChasing == true)
        {
            GetComponent<Animator>().SetInteger("State", 1);
            GetComponent<SpriteRenderer>().flipX = true;
            //gameObject.transform.localScale = new Vector3(0.6092f, 0.4288f);
        }
        

        else if (IsFacingRight() && isChasing == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetInteger("State", 1);
            //gameObject.transform.localScale = new Vector3(-0.6092f, 0.4288f);
        }
       else if (isChasing == false)
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }

    }
    private bool IsFacingRight()
    {
        return direction.x > Mathf.Epsilon;
    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
    }
    private void OnCollisionE2D(Collision2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
    }
    */
}
