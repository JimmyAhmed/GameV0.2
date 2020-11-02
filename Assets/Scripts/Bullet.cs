using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Animator>().SetTrigger("Die");
            Destroy(collision.gameObject);
            FindObjectOfType<playerScore>().IncreaseScore();
        }
        Destroy(gameObject);
    }
}
