using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    
    void Update()
    {
        Vector3 position = transform.position;
        position = Vector3.SmoothDamp(position, player.transform.position, ref velocity, smoothTime);
        position = new Vector3(position.x, position.y, -10);
        transform.position = position;
    }
}
