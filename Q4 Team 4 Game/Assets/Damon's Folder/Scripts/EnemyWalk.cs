using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    Rigidbody2D myRigidbody;

    float inputHorizontal;


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
            myRigidbody.velocity = new Vector2(speed, 0f);
        }  
        else
        {
            myRigidbody.velocity = new Vector2(-speed, 0f);
        }

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0)
        {
            GetComponent<Animator>().SetInteger("State", 1);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }

        if (inputHorizontal < 0)
        {
            GetComponent<Animator>().SetInteger("State", 2);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
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
