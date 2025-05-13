using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    private Manager manager;
    public float teleportDistancePos;
    public float teleportDistanceNeg;
    private bool negative;
    private Vector3 newPos;
    private CharacterController controller;

    private void Awake()
    {
        PlayerMovement playermovement = GetComponent<PlayerMovement>();
        manager = playermovement.manager;

        controller = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TrainTrigger")
        {
            manager.spawnTrain = true;
            Destroy(other.gameObject);
        }
        else
        {
            newPos = transform.position;
            if (other.gameObject.tag == "TriggerPos") { negative = false; }
            else if (other.gameObject.tag == "TriggerNeg") { negative = true; }

            newPos.z = negative ? newPos.z - teleportDistanceNeg : newPos.z + teleportDistancePos;

            controller.enabled = false;
            transform.position = newPos;
            controller.enabled = true;
        }
    }
}
