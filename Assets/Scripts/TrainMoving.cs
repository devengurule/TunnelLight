using UnityEngine;

public class TrainMoving : MonoBehaviour
{
    public GameObject player;
    public bool direction;
    public Vector3 move;
    private Vector3 pos;

    public void Initialize(GameObject player, bool direction, Vector3 move)
    {
        this.player = player;
        this.direction = direction;
        this.move = move;
    }

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (transform.eulerAngles.y == 180)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            move *= -1;
        }
        pos += move;
        transform.position = pos;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TrainStop")
        {
            Destroy(gameObject);
        }
    }
}
