using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject Bullet;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private Animator playerAnimator;
    private float nextBullet;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Fire Code
        if (Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("Fire", true);
            if(Time.time > nextBullet)
            {
                nextBullet = Time.time + fireRate;
                GameObject newBullet = Instantiate(Bullet, fireSpawnPoint.position,Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 50;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerAnimator.SetBool("Fire", false);
        }

    }
}
