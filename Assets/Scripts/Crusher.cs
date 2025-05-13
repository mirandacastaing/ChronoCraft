using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float baseSpeed = 2f;
    public float range = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float speed = baseSpeed * Time.timeScale;
        transform.position = new Vector3(
            startPos.x,
            startPos.y + Mathf.PingPong(Time.time * speed, range),
            0
        );
    }
}
