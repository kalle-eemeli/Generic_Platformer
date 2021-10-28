using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000.0f;
    public float dashVel = 5.0f;
    public float maxSpeed = 5.0f;
    public float jumpSpeed = 1000.0f;
    public float velocityX;
    public float velocityY;
    private Rigidbody playerRb;
    public bool isOnGround;
    public bool isJumping;
    public int jumpCount;
    public bool gameOver;
    private GameObject focalPoint;
    public bool dashCd = false;
    public float movementMultip = 2;
    public Vector3 playerSpawnPos;
    GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        playerSpawnPos = transform.position;
        gameManager = GameManager.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        // if(isOnGround == true)
        // {
        //     movementMultip = 1.0f;
        // }
        // else
        // {
        //     movementMultip = 0.5f;
        // }
        
        PlayerMovement();
    }

    void PlayerMovement()
    {

        velocityX = playerRb.velocity[0];
        velocityY = playerRb.velocity[1];
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // if(velocityX < 5 && velocityX > -5)
        // {
        //     playerRb.AddForce(focalPoint.transform.right * speed * verticalInput * movementMultip);
        // }

        // if(velocityY < 5 && velocityY > -5)
        // {
        //     playerRb.AddForce(focalPoint.transform.forward * speed * -horizontalInput * movementMultip);
        // }

        if(playerRb.velocity.magnitude < maxSpeed)
        {
            playerRb.AddForce(focalPoint.transform.forward * speed * -horizontalInput * movementMultip);
            playerRb.AddForce(focalPoint.transform.right * speed * verticalInput * movementMultip);
        }


        if(Input.GetKeyDown(KeyCode.Q) && isJumping == true && dashCd == false)
        {
            Dash(verticalInput);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
            isJumping = true;
            jumpCount += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isJumping == true && jumpCount < 2)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumpCount += 1;
        }
    }

    private void Dash(float direction)
    {
        if(direction == 0)
        {
            playerRb.AddForce(focalPoint.transform.right * dashVel * -1, ForceMode.Impulse);
        }
        else
        {
            playerRb.AddForce(focalPoint.transform.right * dashVel * direction, ForceMode.Impulse);
        }
        dashCd = true;
        StartCoroutine(dashCooldown());
    }

    IEnumerator dashCooldown()
    {
        yield return new WaitForSeconds(3);
        dashCd = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.SpawnAtCheckpoint();
        }

        else if(other.gameObject.CompareTag("Ground") ^ other.gameObject.CompareTag("JumpPad"))
        {
            isOnGround = true;
            isJumping = false;
            jumpCount = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
