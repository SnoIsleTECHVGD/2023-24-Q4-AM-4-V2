using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public string fruitName;
    public float respawn;
    
    Vector3 death = new Vector3(-100, -100, -100);
    Vector3 alive = new Vector3();

    public void OnCollisionEnter2D (Collision2D collision)
    {

        if ((collision.gameObject.GetComponent("PlayerStats") as PlayerStats) != null)
        {

             if (fruitName == "Jump Fruit")
             {

                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                } 
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = true;
             }
             else if (fruitName == "Fire Fruit")
             {

                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = true;
             }
             else if (fruitName == "Ghost Fruit")
             {
                
                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = true;
             }
             else if (fruitName == "Anti-Gravity Fruit")
             {
                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = true;
                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
             }

            alive = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.position = death;
        }

    }
    void Update()
    {
        if (gameObject.transform.position == death)
        {
            respawn += Time.deltaTime;
            if (respawn >= 60)
            {
                respawn = 0f;
                transform.position = alive;
            }
        }
    }
}
