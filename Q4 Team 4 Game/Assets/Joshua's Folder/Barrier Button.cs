using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierButton : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;

    public bool ButtonIsTriggered;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ButtonIsTriggered = false;
        if (collision.CompareTag("Player"))
        {
            ButtonIsTriggered = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ButtonIsTriggered == true && Vector2.Distance(transform.position, posA.position) < .1f)
        {
            targetPos = posB.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
