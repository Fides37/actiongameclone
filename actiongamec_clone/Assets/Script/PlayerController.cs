using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rigidBody;
    private float speed = 3.5f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private int health = 5;
    private int damage = 1;
    private int calcHealth;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    private float input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        rigidBody.velocity = DinosaurController();
    }


    private Vector2 DinosaurController()
    {
        Vector2 vel = rigidBody.velocity;


        if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
            animator.SetBool("isWalkingVert", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
            animator.SetBool("isWalkingVert", true);
        }
        else
        {
            vel.y = 0;
            animator.SetBool("isWalkingVert", false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking", true);

            vel.x = speed;
        }else if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);

            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
            animator.SetBool("isWalking", false);
        }


        return vel;
    }


    private void CameraMove()
    {
        cam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);


    }



    private void PlayerDamageHealth()
    {
        calcHealth = health - damage;

        if (calcHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void KnockBackBoy()
    {
        if (KBCounter <= 0)
        {
            rigidBody.velocity = new Vector2(input * speed, rigidBody.velocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                rigidBody.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rigidBody.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            damage ++;

            PlayerDamageHealth();
        }
    }

}
