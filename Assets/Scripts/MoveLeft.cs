using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();  
    }

    void Update()
    {
        if(playerController.gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed);    
    }
}
