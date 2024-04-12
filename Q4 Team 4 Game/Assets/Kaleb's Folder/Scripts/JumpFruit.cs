using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFruit : MonoBehaviour
{
    public GameObject player;
    private float jumpNormal;
    private bool on = false;
    private float jumpInc;
    private Movement m;
    private PlayerStats stats;

    void Start()
    {
        m = player.GetComponent<Movement>();
        jumpInc = 2 * m.jumpheight;
        jumpNormal = m.jumpheight;
        stats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (stats.hasEatenJFruit == false)
        {
            m.jumpheight = jumpNormal;
        }
    }
    void OnCollisionEnter2D()
    {
        Debug.Log("FASF");
        on = true;
        if (on == true)
        {
            m.jumpheight = jumpInc;
            on = false;
        }
    }
    
}
