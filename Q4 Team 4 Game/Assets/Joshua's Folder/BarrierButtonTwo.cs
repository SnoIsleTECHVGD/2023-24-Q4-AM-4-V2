using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierButtonTwo : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;

    public bool ButtonIsTriggered;
    GameObject player;
    //public GameObject platform;
    BoxCollider2D boxCollider2D;
    private GameObject barriertwo;

    public bool pressingButtonAnimationTimer = false;
    private bool waitAnimation;
    public int aniWaitTimeButtonTwo;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
        barriertwo = GameObject.FindGameObjectWithTag("Barrier Two");
        Debug.Log(barriertwo);
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void ButtonTwoPress()
    {
        GetComponent<Animator>().SetBool("IsPressingButton", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("IsPressingButton", true);

            Debug.Log("is this working or something like that");
            GetComponent<BoxCollider2D>().isTrigger = true;
            if (GetComponent<BoxCollider2D>().isTrigger == true)
            {
                ButtonIsTriggered = true;
                GetComponent<Animator>().SetInteger("State", 1);

                if (collision.gameObject.GetComponent<PlayerStats>().pressingButtonTwoAnimationTimer == false && waitAnimation == false)
                {
                    waitAnimation = true;
                    Invoke("ButtonTwoPress", 0);
                    Debug.Log("COME ON PLEASE WORK");
                    StartCoroutine(ButtonTwoPressingAnimationWait());
                }

                IEnumerator ButtonTwoPressingAnimationWait()
                {
                    yield return new WaitForSeconds(aniWaitTimeButtonTwo);
                    waitAnimation = false;
                    Debug.Log("please work again");
                    collision.gameObject.GetComponent<Animator>().SetBool("IsPressingButton", false);
                }
            }

            targetPos = posB.position;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ButtonIsTriggered == true)
        {
            barriertwo.transform.position = Vector2.MoveTowards(barriertwo.transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
