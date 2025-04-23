using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    private bool trigger;

    public bool isTriggered()
    {
        return trigger;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Trigger")
        {
            //Debug.Log("Colliding");
            trigger = true;
        }
    }
}
