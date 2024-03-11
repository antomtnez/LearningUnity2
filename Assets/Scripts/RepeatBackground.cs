using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float backgroundWidth;

    void Start()
    {
        startPos = transform.position;
        backgroundWidth = GetComponent<BoxCollider>().size.x / 2;  
    }

    void Update()
    {
        if(transform.position.x < startPos.x - backgroundWidth)
            transform.position = startPos;        
    }
}
