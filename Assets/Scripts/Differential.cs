﻿using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Differential : MonoBehaviour
    {
        [SerializeField] private List<WheelCollider> wheels;
        [SerializeField] private float gearRatio;

        [SerializeField] private float difRpm;

        public float RPM
        {
            get => WheelsRpm * gearRatio;
        }

        public float TORQUE;
        public float WheelsRpm;

        private void FixedUpdate()
        {
            difRpm = RPM;
            CalculateWheelsRpm();
        }

        private void CalculateWheelsRpm()
        {
            if (wheels.Count == 0)
            {
                WheelsRpm = 0;
                return;
            }

            float sum = 0;
            foreach (var wheel in wheels)
            {
                sum += wheel.rpm;
            }

            WheelsRpm = sum / wheels.Count;
        }

        public void AddTorqueToWheels(float torque)
        {
            foreach (var wheel in wheels)
            {
                wheel.motorTorque = torque;
            }
        }

        public void TransmissionTorque(float torque)
        {
            TORQUE = torque * gearRatio;
        }
    }
}