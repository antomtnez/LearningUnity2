using UnityEngine;

public class PlayerControllerZ : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody _playerRb;

    public float jumpForce;
    private bool isOnGround = false;
    private bool canDoubleJump = false;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround)
            {
                //Enter here for the first jump
                Jump();
                isOnGround = false;
            }
            else if(canDoubleJump)
            {
                //Then enter here for double jump ability
                Jump();
                canDoubleJump = false;
            }
        }
    }

    void MovePlayer()
    {
        //Moves the player in X and Z axis
        transform.Translate(new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime);
    }
    
    void Jump()
    {
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canDoubleJump = true;
        }
    }
}
