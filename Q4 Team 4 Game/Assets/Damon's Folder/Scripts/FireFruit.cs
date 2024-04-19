using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireFruit : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent("EnemyStats") as EnemyStats) != null)
        {

            collision.GetComponent<EnemyStats>().health -= player.GetComponent<PlayerStats>().damage;

            if(collision.GetComponent<EnemyStats>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
