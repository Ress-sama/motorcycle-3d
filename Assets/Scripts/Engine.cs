using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Rendering;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    [SerializeField] private AnimationCurve Torque;


    [SerializeField] private float IdleRPM;
    [SerializeField] private float IncraseSpeed;
    private float MaxRPM;
    public float TORQUE => Torque.Evaluate(RPM);
    public float RPM;
    public float TRANSMISSION_RPM;


    private void Awake()
    {
        MaxRPM = Torque.keys[Torque.keys.Length - 1].time;
    }

    private void FixedUpdate()
    {
        Process(Input.GetAxis("Vertical"));
    }

    private void Process(float throttle)
    {
        RPM += TRANSMISSION_RPM;
        RPM = Mathf.Lerp(RPM, MaxRPM * throttle, Time.fixedDeltaTime * IncraseSpeed);
    }
}