using UnityEngine;

public class PillarSpawnerScript: MonoBehaviour
{
    //private variables
    private float timer = 0;

    //public variables
    public GameObject pillar;
    public float spawnRate = 2;
    public float heightOffset = 0.55f;
    public BatScript bat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
        bat = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        if (bat.batIsAlive)
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;

            Instantiate(pillar, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }
}
