using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class JumpFruit : MonoBehaviour
{
    public GameObject player;
    private float jumpNormal;
    private bool on = false;
    private float jumpInc;
    private float m;
    private PlayerStats stats;

    void Start()
    {
        GameObject.FindWithTag("Player");
        m = player.GetComponent<MovementBackup>().jumpheight;
        jumpInc = 2 * m;
        jumpNormal = m;
        stats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (stats.hasEatenJFruit == false && stats.hasEatenAGFruit == false)
        {
            m = jumpNormal;
            player.GetComponent<MovementBackup>().jumpheight = m;
        }
    }
    void OnCollisionEnter2D()
    {
        on = true;
        if (on == true)
        {
            player.GetComponent<PlayerStats>().fruitTimer = 30;
            m = jumpInc;
            Debug.Log(m);
            player.GetComponent<MovementBackup>().jumpheight = m;
            on = false;
        }
    }
    
}
