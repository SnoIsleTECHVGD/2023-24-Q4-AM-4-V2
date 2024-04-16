using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGravFruit : MonoBehaviour
{
    public GameObject player;
    private bool s = false;
    private bool timerZero = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerStats>().fruitTimer == 0f)
        {
            timerZero = true;
        }
        else
        {
            timerZero = false;
        }

        if (s == true && timerZero == true)
        {
            s = false;
        }
    }
    void OnCollisionEnter2D()
    {
        s = true;
        player.GetComponent<PlayerStats>().fruitTimer = 30f;
    }
}
