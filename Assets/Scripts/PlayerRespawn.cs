using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position; // Default to initial spawn point
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = respawnPoint;
    }
}
