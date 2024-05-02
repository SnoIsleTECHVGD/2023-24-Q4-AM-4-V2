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
    public bool eatingAnimationTimer = false;
    public bool attackAnimationTimer = false;
    private bool waitAnimation;
    public int aniWaitTimeOne;
    public int aniWaitTimeTwo;
    public int aniWaitTimeThree;
    public bool pressingButtonOneAnimationTimer;
    public bool pressingButtonTwoAnimationTimer;
    public bool pressingButtonThreeAnimationTimer;
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
                GetComponent<PlayerStats>().healthBar.fillAmount = (GetComponent<PlayerStats>().health * 1.0f) / GetComponent<PlayerStats>().maxHealth;
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

    private void Attacking()
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && hasEatenFFruit)
        {
            fireAttack.SetActive(true);
            if (this.gameObject.GetComponent<PlayerStats>().attackAnimationTimer == false && waitAnimation == false)
            {
                waitAnimation = true;
                Invoke("Attacking", 0);
                StartCoroutine(AttackAnimationWait());
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fireAttack.SetActive(false);
        }

        IEnumerator AttackAnimationWait()
        {
            yield return new WaitForSeconds(aniWaitTimeTwo);
            waitAnimation = false;
            Debug.Log("yep uhuh");
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }


        if (fruitTimer > 0)
        {
            fruitTimer -= Time.smoothDeltaTime;
            timer.text = ((int)fruitTimer).ToString();
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
        fruitTimer = 0;
        timer.text = "";
        fireAttack.SetActive(false);
      }

    }
}