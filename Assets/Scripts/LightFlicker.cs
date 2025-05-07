using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float max = 0.1f;
    public float min = 1f;
    public float smooth = 0.1f;
    public float intensity = 150f;
    private Light lightObject;
    private float targetIntensity;
    private float smoothIntensity;

    void Start()
    {
        lightObject = GetComponent<Light>();
        targetIntensity = intensity;
        smoothIntensity = intensity;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameObject.tag == "Flashlight")
        {
            if(lightObject.enabled) lightObject.enabled = false;
            else lightObject.enabled = true;
        }


        if (Mathf.Abs(smoothIntensity - targetIntensity) < 0.01f)
        {
            targetIntensity = intensity * Random.Range(min, max);
        }

        smoothIntensity = Mathf.Lerp(smoothIntensity, targetIntensity, Time.deltaTime * smooth);
        lightObject.intensity = smoothIntensity;
    }
}
