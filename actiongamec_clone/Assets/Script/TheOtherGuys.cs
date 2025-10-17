using System.Collections.Generic;
using UnityEngine;
// IMPORTANT !!! In order to utilize DoTween, you need to make sure to include the Using DG.Tweening line.
using DG.Tweening;

public class TheOtherGuys : MonoBehaviour
{
    // reference to our player.
    public GameObject theGuy;

    // How Fast our enemy can move.
    public float moveSpeed = 3f;

    // Max distance the enemy can move away from the player.
    public float radius = 5f;

    // The originpoint we center our movemnent around.
    private Vector2 originPoint;

    // The position we want to move our enemy to.
    private Vector3 newPos;


    public Sequence enemySequence = DOTween.Sequence();

    // Start is called before the first frame update
    void Start()
    {
        originPoint = theGuy.transform.position;

        newPos = SetNewPosition(originPoint, radius);
    }

    // Update is called once per frame
    void Update()
    {

        // If our object is not where it needs to be.
        if (gameObject.transform.position != newPos)
        {
            // We calculate the time it takes for our enemy
            // to reach its new destination relative to it's speed.
            float timeToDistance = (Vector2.Distance(
            gameObject.transform.position, newPos) / moveSpeed);

            // We add a new tween to our sequence,
            // moving the transform position to our new position over a set time.
            enemySequence.Append(gameObject.transform.DOMove(newPos, timeToDistance));
        }
        else // otherwise if it's where it's supposed to be.
        {
            /*
            * You can add timer functionality here if you want the enemy to wait before
            * finding/moving to it's next destination.
            */

            // grab a new origin point.
            originPoint = theGuy.transform.position;

            // set a new point around that origin point.
            newPos = SetNewPosition(originPoint, radius);

            // kill the tweening sequence.
            // tweens are usually killed when they finish.
            // But just in case we want to make sure it's cleared.
            enemySequence.Kill();
        }
    }

    // takes an origin point and a radius to create a circle around said origin point.
    private Vector3 SetNewPosition(Vector2 origin, float r)
    {
        // creates a vector2 that will hold our new position.
        Vector2 pos = origin;

        // set new x position to a space anywhere within that radius around central point.
        pos.x += Random.Range(-r, r);
        // do the same for y.
        pos.y += Random.Range(-r, r);

        // return our new updated position for the enemy to move to.
        return pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }


}