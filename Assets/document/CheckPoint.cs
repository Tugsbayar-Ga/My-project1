using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;
            other.GetComponent<PlayerRespawn>().SetCheckpoint(transform.position);
        }
    }
}