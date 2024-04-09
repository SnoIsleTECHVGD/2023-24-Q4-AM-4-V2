using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    
    public Transform player;
    
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
        player = GameObject.Find("Player").transform;
        
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
            DealDamage();
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
        player.GetComponent<PlayerStats>().health -= damageDealing;
    }
}
