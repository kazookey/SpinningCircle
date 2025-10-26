using UnityEngine;

public class SpawnRange : MonoBehaviour
{
    public float speed = 200f;

    void Update()
    {
        transform.localPosition += Vector3.right * speed * Time.deltaTime;

        if (transform.localPosition.x > 600f)
        {
            Destroy(gameObject);
        }
    }
}
