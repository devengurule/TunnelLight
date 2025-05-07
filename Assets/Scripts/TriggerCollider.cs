using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public Manager manager;
    public float teleportDistance;
    private bool negative;
    private Vector3 newPos;
    private CharacterController controller;

    private void Awake()
    {
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

            newPos.z = negative ? newPos.z - teleportDistance : newPos.z + teleportDistance;

            controller.enabled = false;
            transform.position = newPos;
            controller.enabled = true;
        }
    }
}
