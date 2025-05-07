using UnityEngine;

public class TrainMoving : MonoBehaviour
{
    public Manager manager;
    public GameObject player;
    public bool direction;
    public Vector3 move;
    public Vector3 startpos;
    private Vector3 pos;

    TrainMoving(Manager manager, GameObject player, bool direction, Vector3 move, Vector3 startpos)
    {
        this.manager = manager;
        this.player = player;
        this.direction = direction;
        this.move = move;
        this.startpos = startpos;
    }

    void Start()
    {
        pos = startpos;
        
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
