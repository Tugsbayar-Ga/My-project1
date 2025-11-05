using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 pos = transform.position;
    pos.x = Target.transform.position.x;
    transform.position = pos;
    }
}
