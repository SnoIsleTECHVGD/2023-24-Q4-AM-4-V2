using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    
    public GameObject player;
    
    public int maxHealth;
    public int health;
    
    public int baseDamage;
    public int damageDealing;
    
    public bool hasEatenJFruit;
    public bool hasEatenGFruit;
    public bool hasEatenFFruit;
    public bool hasEatenAGFruit;
    
    private void Awake()
    {
        player = GameObject.Find("Player");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            health -= player.GetComponent<PlayerStats>().damage;
            TakeDamage(player.GetComponent<PlayerStats>().damage);
            player.GetComponent<PlayerStats>().healthBar.fillAmount = (player.GetComponent<PlayerStats>().health * 1.0f) / player.GetComponent<PlayerStats>().maxHealth;
            DealDamage();

            if (player.GetComponent<PlayerStats>().health <= 0)
            {
                
                SceneManager.LoadScene("Lose Screen");
            }
        } 
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            DestroyEnemy();
        
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void DealDamage()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        player.GetComponent<PlayerStats>().health -= damageDealing;

        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
