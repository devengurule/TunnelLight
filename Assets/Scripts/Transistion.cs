using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class Transistion : MonoBehaviour
{
    public bool transition = false;
    Volume volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transition = true;
        }

        if (transition)
        {
            if (volume.weight == 1f)
            {
                volume.weight = 0f;
            }
            else
            {
                volume.weight = 1f;
            }
            transition = false;
        }

    }
}
