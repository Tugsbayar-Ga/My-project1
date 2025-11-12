using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset = new Vector3(0f, 0f, -10f);
     float time = 0.25f;
    private Vector3 velocity = Vector3.zero;
    
    [SerializeField] public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, time);
    }
}
