using UnityEngine;

public class FlashLightFlicker : MonoBehaviour
{
    private Manager manager;
    public float max = 0.1f;
    public float min = 1f;
    public float smooth = 0.1f;
    public float intensity = 150f;
    private Light lightObject;
    private float targetIntensity;
    private float smoothIntensity;
    private bool disabled = true;
    void Start()
    {
        GameObject parentObject = transform.parent.parent.parent.parent.gameObject;
        PlayerMovement playermovement = parentObject.GetComponent<PlayerMovement>();
        manager = playermovement.manager;

        lightObject = GetComponent<Light>();
        targetIntensity = intensity;
        smoothIntensity = intensity;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameObject.tag == "Flashlight" && manager.playable)
        {
            if (!disabled) disabled = true;
            else disabled = false;
        }


        if (Mathf.Abs(smoothIntensity - targetIntensity) < 0.01f)
        {
            if(!disabled) targetIntensity = intensity * Random.Range(min, max);
            else targetIntensity = 0f;
        }

        smoothIntensity = Mathf.Lerp(smoothIntensity, targetIntensity, Time.deltaTime * smooth);
        if(smoothIntensity < 0) smoothIntensity = 0;
        lightObject.intensity = smoothIntensity;
    }
}
