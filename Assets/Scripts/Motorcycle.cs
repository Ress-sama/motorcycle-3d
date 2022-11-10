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
        [SerializeField] private Steering steering;
        [SerializeField] private Brakes breake;

        [SerializeField] private float wheelRpmLimit;
        [SerializeField] private float torqueToWheel;


        [SerializeField] private float verticalInput;
        [SerializeField] private float horizontalInput;

        private void Awake()
        {
        }

        private void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if (verticalInput < 0)
            {
                transmission.Clutch = Mathf.Abs(verticalInput);
            }
            else
            {
                transmission.Clutch = 0;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transmission.UpShift();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                transmission.DownShift();
            }

            breake.ApplyBrake(verticalInput);
            steering.SteerWheels(horizontalInput);

            engine.Process(verticalInput, transmission.RPM);
            transmission.EngineTorque(engine.TORQUE);
            differential.TransmissionTorque(transmission.Torque);

            wheelRpmLimit = (engine.MaxRPM / transmission.CurrentGearRatio) / differential.GearRatio;
            torqueToWheel = differential.TORQUE;
            if (differential.WheelsRpm > wheelRpmLimit)
            {
                torqueToWheel = 0;
            }
            differential.AddTorqueToWheels(torqueToWheel);

            transmission.UpdateRpm(differential.RPM);
        }
    }
}