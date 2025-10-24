using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScript : MonoBehaviour
{
    private Vector2 target;
    private float speed;
    private GameObject mana;

    private int health = 10;
    private int bulletDamage = 1;

    public GameObject player;

    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("Mana");

        triggered = false;

        speed = .5f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        ManaMovement();

        Debug.Log(health);

        CalcDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("yay");
            triggered = true;
        }
        
    }

    private void ManaMovement()
    {
        if (triggered)
        {
            gameObject.transform.position = Vector2.MoveTowards(mana.transform.position, player.transform.position, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("I got hit!");
            health--;
            Destroy(collision.gameObject);
            
        }
    }


    private void CalcDamage()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
