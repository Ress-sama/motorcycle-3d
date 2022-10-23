using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Rendering;
using UnityEditor.UIElements;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float Power;
    public float Torque;
    [SerializeField] private float minRpm;
    [SerializeField] private float maxRpm;
    private bool isActive;
    private float gasLevel { get; set; }
    public float motorRPM { get; set; }

    private void Awake()
    {
        gasLevel = 0.1f;
    }

    private void FixedUpdate()
    {
        RotateMotor();
        UpdateGasLevel();
    }

    public void StartEngine()
    {
        isActive = true;
    }

    public void StopEngine()
    {
        isActive = false;
    }

    private void RotateMotor()
    {
        if (!isActive) return;
        motorRPM = Mathf.Lerp(motorRPM, gasLevel * maxRpm * 1000, Time.deltaTime / 50);
        Torque = 63.025f * Power / motorRPM;
    }

    public void Gas(float value)
    {
        gasLevel = value;
    }

    private void UpdateGasLevel()
    {
        if (gasLevel <= 0.1f)
        {
            gasLevel = 0.1f;
            return;
        }

        gasLevel -= 1 * Time.fixedDeltaTime;
    }

    private void AffectRpm(float affect)
    {
        motorRPM -= affect;
    }
}