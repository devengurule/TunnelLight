using UnityEngine;

public class Headbob : MonoBehaviour
{

    public Camera cam;
    private Vector3 startPos;
    private float x;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        cam.transform.position = startPos;

        startPos.y = Mathf.Sin(1);
    }
}
