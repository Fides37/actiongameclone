using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class CatController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rigidBody;
    private float speed = 3.5f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private int health = 5;
    private int damage = 1;
    private int calcHealth;

    public TextMeshProUGUI guyDialogue;
    public GameObject guyPanel;

    // Start is called before the first frame update
    void Start()
    {
        guyDialogue.text = "";
        guyPanel.SetActive(false);
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mana")
        {
            Destroy(gameObject);

            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GuyDialogue")
        {
            guyPanel.SetActive(true);
            guyDialogue.text = "[E] to interact";

            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Yo gurt");
                guyDialogue.text = "There's something weird happening in this maze. I can sense it.";
            }


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "GuyDialogue")
        {
            if (Input.GetKey(KeyCode.E))
            {
            Debug.Log("Yo gurt");
            guyDialogue.text = "There's something weird happening in this maze. I can sense it.";
            }

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "GuyDialogue")
        {
            guyPanel.SetActive(false);
            guyDialogue.text = "";
        }
    }


}
