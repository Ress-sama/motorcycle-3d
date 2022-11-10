using System;
using Riyezu.CarSystem;
using UnityEngine;

namespace Riyezu
{
    public class Motorcycle : MonoBehaviour
    {
        [SerializeField] private Engine engine;
        [SerializeField] private Transmission transmission;
        [SerializeField] private Differential differential;

        private float verticalInput;

        private void Awake()
        {
        }

        private void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transmission.UpShift();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                transmission.DownShift();
            }

            engine.Process(verticalInput, transmission.RPM);
            transmission.EngineTorque(engine.TORQUE);
            differential.TransmissionTorque(transmission.Torque);
            if (differential.WheelsRpm < engine.MaxRPM)
            {
                differential.AddTorqueToWheels(differential.TORQUE);
            }

            transmission.UpdateRpm(differential.RPM);
        }
    }
}