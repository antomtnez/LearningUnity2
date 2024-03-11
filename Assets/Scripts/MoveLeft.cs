using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;
    private PlayerController playerController;

    private float leftBound = -15f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();  
    }

    void Update()
    {
        if(playerController.gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed); 

        DestroyAtTheLeftBound(); 
    }

    //This destroy the obstacles when them arrives at left bound
    void DestroyAtTheLeftBound()
    {
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
