using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public int baseDamage;
    public int damage;

    public bool hasEatenJFruit;
    public bool hasEatenGFruit;
    public bool hasEatenFFruit;
    public bool hasEatenAGFruit;

    public float fruitTimer;
    [SerializeField] TextMeshProUGUI timer;


    // Damage player
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent("EnemyStats") as EnemyStats) != null)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;

            if (collision.gameObject.GetComponent<EnemyStats>().damageDealing >= 1)
            {
                health -= collision.gameObject.GetComponent<EnemyStats>().damageDealing;
                gameObject.GetComponent<Renderer>().material.color = Color.red;

                // Death
                if (health <= 0)
                {
                    Console.WriteLine("YOU DIED");
                }
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent("EnemyStats") as EnemyStats) != null)
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      if (fruitTimer > 0)
      {
            fruitTimer -= Time.smoothDeltaTime;
            timer.text =  fruitTimer.ToString();
      }

      else
      {
        if (hasEatenAGFruit == true)
        {
          hasEatenAGFruit = false;
        }
        else if (hasEatenFFruit == true)
        {
          hasEatenFFruit = false;
        } 
        else if (hasEatenGFruit == true)
        {
          hasEatenGFruit = false;
        } 
        else if (hasEatenJFruit == true)
        {
          hasEatenJFruit = false;
        }
        fruitTimer = 0f;
            timer.text = "";
      }
    }
}