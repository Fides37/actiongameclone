using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShooting : MonoBehaviour
{
    private bool canFire;
    public GameObject bullet;
    public Transform bulletTransform;
    private float timer;
    private float timeBetweenFiring;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown((0)) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }



    }



}
