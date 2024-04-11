using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFruit : MonoBehaviour
{
    public GameObject player;
    private bool on = false;

    void Update()
    {

    }
    OnCollisionEnter2D()
    {
        Debug.Log("FASF");
        on = true;
        if (on = true)
        {
            player.Movement.Jumpbool = 2 * player.Movement.Jumpbool;
            on = false;
        }
    }
}
