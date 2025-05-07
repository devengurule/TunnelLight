using Unity.VisualScripting;
using UnityEngine;

public class IntroPlayer : MonoBehaviour
{
    public float speed;
    private Vector3 pos;
    private CharacterController controller;
    void Start()
    {
        pos = transform.position;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        pos.z += speed;
        transform.position = pos;
        //controller.Move(new Vector3(0,0, speed) * Time.deltaTime);
    }
}
