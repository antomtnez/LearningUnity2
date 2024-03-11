using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25f, 0f, 0f);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerController;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerController = FindObjectOfType<PlayerController>();
    }

    void SpawnObstacle()
    {
        if(playerController.gameOver == false)
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
