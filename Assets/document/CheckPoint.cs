using UnityEngine;

public class CheckPoint : MonoBehaviour
{

  private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            
        }
    }
    
}
