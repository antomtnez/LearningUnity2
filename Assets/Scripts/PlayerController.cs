using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100f;
    public float gravityModifier;

    private Rigidbody _rb;
    private bool isOnGround = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
            isOnGround = false;
        }
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) 
    {
        isOnGround = true;    
    }
}
