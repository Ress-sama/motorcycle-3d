using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Differential : MonoBehaviour
    {
        [SerializeField] private List<Wheel> wheels;
        [SerializeField] private Transmission transmission;

        [SerializeField] private float torque;

        private void FixedUpdate()
        {
            TurnWheels();
        }

        private void TurnWheels()
        {
            foreach (var wheel in wheels)
            {
                wheel.Turn(torque);
            }
        }
    }
}