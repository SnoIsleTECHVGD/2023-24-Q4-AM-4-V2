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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("is this working or something like that");
            GetComponent<BoxCollider2D>().isTrigger = true;
            if (GetComponent<BoxCollider2D>().isTrigger == true)
            {
                ButtonIsTriggered = true;
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
