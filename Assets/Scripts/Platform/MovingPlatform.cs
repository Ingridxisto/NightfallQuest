using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        if (platform == null) return;

        
        platform.position = pointA.position;
        targetPosition = pointB.position;
    }

    void Update()
    {
        if (platform == null) return;

        platform.position = Vector3.MoveTowards(
            platform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        
        if (Vector3.Distance(platform.position, targetPosition) < 0.1f)
        {
            targetPosition = 
                (targetPosition == pointB.position) ? 
                pointA.position : 
                pointB.position;
        }
    }
}
