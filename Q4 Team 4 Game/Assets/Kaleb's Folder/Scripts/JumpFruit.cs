using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFruit : MonoBehaviour
{
    public GameObject player;
    private bool on = false;
    private Movement m;

    void Start()
    {
        m = player.GetComponent<Movement>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D()
    {
        Debug.Log("FASF");
        on = true;
        if (on = true)
        {
            m.jumpbool = 2 * m.jumpbool;
            on = false;
        }
    }
    
}
