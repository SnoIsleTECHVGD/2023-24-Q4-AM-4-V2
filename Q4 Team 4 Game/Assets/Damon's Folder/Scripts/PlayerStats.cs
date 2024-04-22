using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public int baseDamage;
    public int damage;

    public bool hasEatenJFruit;
    public bool hasEatenGFruit;

    public bool hasEatenFFruit;
    public GameObject fireAttack;

    public bool hasEatenAGFruit;

    public float fruitTimer;
    [SerializeField] TextMeshProUGUI timer; 
    public Image healthBar;



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
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    SceneManager.LoadScene("Lose Screen");
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
       
        if (Input.GetMouseButtonDown(0) && hasEatenFFruit)
        {
            fireAttack.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fireAttack.SetActive(false);
        }
        
        
        
        
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
        fireAttack.SetActive(false);
        }
    }
}