using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Headbob : MonoBehaviour
{
    public Manager manager;
    public float Amplitude;
    public float RunAmplitude;
    public float Frequency;
    public float RunFrequency;
    public float Smooth;
    private float CurrentFrequency;
    private float CurrentAmplitude;
    private Vector3 pos;
    private Vector3 startPos;
    private Vector3 startPosTest;
    

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StopHeadBob();
            CurrentFrequency = RunFrequency;
            CurrentAmplitude = RunAmplitude;
        }
        else
        {
            StopHeadBob();
            CurrentFrequency = Frequency;
            CurrentAmplitude = Amplitude;
        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (manager.playable) HeadBob();
        }
        else StopHeadBob();
    }

    private void HeadBob()
    {
        startPosTest = transform.localPosition;

        pos = transform.position;

        pos.y += Mathf.Lerp(0, Mathf.Sin(Time.time * CurrentFrequency) * CurrentAmplitude, Smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(0, Mathf.Cos(Time.time * CurrentFrequency / 2f) * CurrentAmplitude, Smooth * Time.deltaTime);
        
        transform.position = pos;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == startPos) return;

        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime);
    }
}
