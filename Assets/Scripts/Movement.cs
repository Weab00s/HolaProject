using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Gun[] guns;
    private bool isDead;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;

    [Header("Player Settings")]
    [SerializeField] float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
      guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.S);
        moveRight = Input.GetKey(KeyCode.D);
        moveLeft = Input.GetKey(KeyCode.A);

        shoot = Input.GetKeyDown(KeyCode.Space);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
            
        }
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x *  move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;
        if (pos.x <= 0.75f)
        {
            pos.x = 0.75f;
        }
        if (pos.x >= 7.66f)
        {
            pos.x = 7.66f;
        }
        if (pos.y <= 1.5)
        {
            pos.y = 1.5f;
        }
        if (pos.y >= 5.4)
        {
            pos.y = 5.4f;
        }
        transform.position = pos;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        




        //if (collision.transform.tag == "Enemy")
        //{
            //Debug.Log("Game Over");
        //}

        //Destructable destructable = collision.GetComponent<Destructable>();
        //if (destructable != null)
        //{
           
            //Destroy(gameObject);
            
        //}
       
    //}

}
