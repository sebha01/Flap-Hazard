using UnityEngine;

public class PillarMoveScript : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float deadZone = -1.9f;
    public BatScript bat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bat = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bat.batIsAlive)
        {
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Debug.Log("Pillar Game Object Deleted");
                Destroy(gameObject);
            }
        }
    }
}
