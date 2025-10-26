using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public GameObject obstaclePrefab;
    public RectTransform canvasTransform;

    public float spawnYMin = -200f;
    public float spawnYMax = 200f;
    public float spawnX = -500f;
    public float spawnInterval = 2f;

    private float timer;
    private bool isSpawning = true;

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        bool spawnCollectible = Random.value > 0.5f;
        GameObject prefab = spawnCollectible ? collectiblePrefab : obstaclePrefab;

        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(canvasTransform, false);

        RectTransform rt = obj.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(spawnX, Random.Range(spawnYMin, spawnYMax));

        SpawnRange mover = obj.GetComponent<SpawnRange>();
        if (mover != null) mover.speed = 200f;
    }

    public void StopSpawning()
    {
        isSpawning = false;

        
        foreach (Transform child in canvasTransform)
        {
            if (child.name.Contains("Collectible") || child.name.Contains("Obstacle"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
