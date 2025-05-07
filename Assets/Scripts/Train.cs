using UnityEngine;

public class Train : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    private Vector3 posDelta;
    void Start()
    {
        pos = transform.position;
        posDelta = pos - player.transform.position;
        
    }
    
    void LateUpdate()
    {
         transform.position = player.transform.position + posDelta;
    }
}
