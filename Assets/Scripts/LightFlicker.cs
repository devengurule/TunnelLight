using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float max = 0.1f;
    public float min = 1f;
    public float intensity = 150f;
    private Light lightObject;

    void Start()
    {
        lightObject = GetComponent<Light>();
    }
    void Update()
    {
        lightObject.intensity = intensity * Random.Range(min, max);
    }
}
