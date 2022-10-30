using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Differential : MonoBehaviour
    {
        [SerializeField] private List<Wheel> wheels;
        [SerializeField] private Transmission transmission;
        [SerializeField] private float gearRatio;
        [SerializeField] private float TORQUE;
        [SerializeField] private float RPM;

        private void FixedUpdate()
        {
            TORQUE = transmission.Torque * gearRatio;
            RPM = transmission.RPM / gearRatio;
            Process();
        }

        private void Process()
        {
            foreach (var item in wheels)
            {
                item.DifferentialRPM = RPM;
                item.toruqe = TORQUE / 2;
            }
        }
    }
}