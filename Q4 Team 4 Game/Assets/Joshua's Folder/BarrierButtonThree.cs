using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierButtonThree : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;

    public bool ButtonIsTriggered;
    GameObject player;
    //public GameObject platform;
    BoxCollider2D boxCollider2D;
    private GameObject barrierthree;

    public bool pressingButtonAnimationTimer = false;
    public bool waitAnimation;
    public int aniWaitTimeButtonThree;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
        barrierthree = GameObject.FindGameObjectWithTag("Barrier Three");
        Debug.Log(barrierthree);
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

                if (collision.gameObject.GetComponent<PlayerStats>().pressingButtonThreeAnimationTimer == false && waitAnimation == false)
                {
                    waitAnimation = true;
                    Invoke("ButtonThreePress", 0);
                    StartCoroutine(ButtonThreePressingAnimationWait());
                }

                IEnumerator ButtonThreePressingAnimationWait()
                {
                    yield return new WaitForSeconds(aniWaitTimeButtonThree);
                    waitAnimation = false;
                    Debug.Log("yep uhuh");
                    collision.GetComponent<Animator>().SetBool("IsPressingButton", false);
                }
                targetPos = posB.position;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ButtonIsTriggered == true)
        {
            barrierthree.transform.position = Vector2.MoveTowards(barrierthree.transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
