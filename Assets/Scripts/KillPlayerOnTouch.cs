using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
