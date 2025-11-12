using UnityEngine;
using UnityEngine.SceneManagement; // för att byta scen

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
    {
        SceneManager.LoadScene("End");
    }
    }
}
