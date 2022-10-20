using UnityEngine;

public class Wall : MonoBehaviour
{
    private const float MIN_Y = -2.5f;
    private const float MAX_Y = 2.5f;
    private const float SPEED = 5f;
    private const float MIN_X = -10f;
    private const float SPAWN_X = 20f;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(MIN_Y, MAX_Y), transform.position.z);
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        x -= SPEED * Time.deltaTime;
        y = x < MIN_X ? Random.Range(MIN_Y, MAX_Y) : y;
        x = x < MIN_X ? SPAWN_X : x;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
