using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Headbob : MonoBehaviour
{
    public float Amplitude;
    public float Frequency;
    public float RunFrequency;
    public float Smooth;
    private float CurrentFrequency;
    private Vector3 pos;
    private Vector3 startPos;
    private Vector3 startPosTest;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) CurrentFrequency = RunFrequency;
        else CurrentFrequency = Frequency;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) HeadBob();
        else StopHeadBob();
    }

    private void HeadBob()
    {
        startPosTest = transform.localPosition;

        pos = transform.position;

        pos.y += Mathf.Lerp(0, Mathf.Sin(Time.time * CurrentFrequency) * Amplitude, Smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(0, Mathf.Cos(Time.time * CurrentFrequency / 2f) * Amplitude, Smooth * Time.deltaTime);
        transform.position = pos;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == startPos) return;

        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime);
    }
}
