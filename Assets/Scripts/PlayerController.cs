using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;
    private bool isOnGround = false;

    private Rigidbody _rb;
    private Animator _playerAnimator;

    public bool gameOver = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
            isOnGround = false;
            _playerAnimator.SetTrigger("Jump_trig");
        }
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
            isOnGround = true;

        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");    
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
        }
            
    }
}
