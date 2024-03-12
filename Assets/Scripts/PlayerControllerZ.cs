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

        //Moves the player in X and Z axis
        transform.Translate(new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround)
            {
                Jump();
                isOnGround = false;
            }
            else if(canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canDoubleJump = true;
        }
    }

    void Jump()
    {
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
