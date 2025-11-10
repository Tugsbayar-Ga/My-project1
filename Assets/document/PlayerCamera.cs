using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float time = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform traget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tragetPosition = traget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, tragetPosition, ref velocity, time);
    }
}
