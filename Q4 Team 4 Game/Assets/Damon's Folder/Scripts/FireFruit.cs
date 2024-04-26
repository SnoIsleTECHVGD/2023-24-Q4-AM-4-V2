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
        if (player.GetComponent<SpriteRenderer>().flipX && transform.position.x > 0)
        {
            transform.position = new Vector3(-3 + player.transform.position.x, 0.715f + player.transform.position.x, 0);
        }
        else if (player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.position = new Vector3(3 + player.transform.position.x, 0.715f + player.transform.position.x, 0);
        }
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
