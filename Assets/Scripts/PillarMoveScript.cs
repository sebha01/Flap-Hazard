using UnityEngine;

public class PillarMoveScript : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float deadZone = -1.9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
