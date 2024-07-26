using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class Movement : MonoBehaviour
{
    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] float minY = -4f;
    [SerializeField] float maxY = 4f;



    Gun[] guns;
    private bool isDead;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    [SerializeField] GameObject model;
    [SerializeField] float speed = 5f;
    [SerializeField] float smoothness = 0.1f;
    [SerializeField] float leanAngle = 15f;
    
    [Header("Camera Bounds")]
    [SerializeField]
    Transform cameraFollow;
    bool shoot;
    InputReader input;
    Vector3 currentVelocity;
    Vector3 targetposition;




    [Header("Player Settings")]
    [SerializeField] float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
      guns = transform.GetComponentsInChildren<Gun>();
      input = GetComponent<InputReader>();
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
        var minPlayerX = cameraFollow.position.x + minX;
        var maxPlayerX = cameraFollow.position.x + maxX;
        var minPlayerY = cameraFollow.position.y + minY;
        var maxPlayerY = cameraFollow.position.y + maxY;
       
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
        if (pos.x <= -26.26f)
        {
            pos.x = -26.26f;
        }
        if (pos.x >= 315.3f)
        {
            pos.x = 315.3f;
        }
        if (pos.y <= -7.01)
        {
            pos.y = -7.01f;
        }
        if (pos.y >= 2.75)
        {
            pos.y = 2.75f;
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
