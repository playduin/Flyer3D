using UnityEngine;

public class Player : MonoBehaviour
{
    private const float GRAVITY = 20f;
    private const float FORCE = 10f;
    private const float MIN_Y = -3f;
    private const float MAX_Y = 3f;
    private const float FAIL_TIME = 2f;
    private GameObject playerFail;
    private float velocity = 0f;
    private float failTimer = 0.0f;

    void Start()
    {
        playerFail = transform.Find("PlayerFail").gameObject;
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        y += velocity * Time.deltaTime;
        velocity = (y > MAX_Y || y < MIN_Y) ? 0f : velocity;
        y = Mathf.Max(Mathf.Min(y, MAX_Y), MIN_Y);
        transform.position = new Vector3(x, y, 0);

        velocity += FORCE * (getJump() ? 1f : 0f) - GRAVITY * Time.deltaTime;

        failTimer = Mathf.Max(failTimer - Time.deltaTime, 0.0f);
        playerFail.SetActive(failTimer > 0.0f);
    }

    void OnTriggerEnter(Collider col) {
        failTimer = "Wall".Equals(col.tag) ? FAIL_TIME : failTimer;
    }

    private bool getJump() {
        return Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);
    }
}
