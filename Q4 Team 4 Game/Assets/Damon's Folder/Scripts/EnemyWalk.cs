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
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
    
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
       
        inputHorizontal = Input.GetAxisRaw("Horizontal"); 

        if (inputHorizontal > 0)
        {
            GetComponent<Animator>().SetInteger("State", 1);
            gameObject.transform.localScale = new Vector3(0.6092f, 0.4288f);
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }

        if (inputHorizontal < 0)
        {
            GetComponent<Animator>().SetInteger("State", 2);
            gameObject.transform.localScale = new Vector3(-0.6092f, 0.4288f);
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }
    
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
    }
}
