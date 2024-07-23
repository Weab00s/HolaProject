using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {





        if (collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {

            Destroy(gameObject);

        }

    }

}


