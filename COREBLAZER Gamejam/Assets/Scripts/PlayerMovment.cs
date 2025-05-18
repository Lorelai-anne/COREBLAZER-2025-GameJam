using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed;
    public float sprintSpeed = 8.0f;
    public float walkspeed = 5.0f;
    public float jumpHeight = 5.0f;

    private bool isMoving = false;
    private bool isGrounded = true;

    private Animator anim;
    private Rigidbody rigidBody;

    private void Start()
    {
        playerSpeed = walkspeed;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        isMoving = false;

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkspeed;
        }
        

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {
            isMoving = true;
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && isGrounded)
        {
            isMoving = true;
            transform.position += Vector3.back * playerSpeed * Time.deltaTime;
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && isGrounded)
        {
            isMoving = true;
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && isGrounded)
        {
            isMoving = true;
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            transform.position += Vector3.up * jumpHeight * Time.deltaTime;
            
        }
    }
}
