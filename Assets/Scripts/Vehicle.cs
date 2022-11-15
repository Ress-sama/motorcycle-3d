using System;
using Riyezu.CarSystem;
using UnityEngine;

namespace Riyezu
{
    public class Vehicle : MonoBehaviour
    {
        public float KPH;

        [SerializeField] private Rigidbody rigidbody;

        [SerializeField] private Engine engine;
        [SerializeField] private Transmission transmission;
        [SerializeField] private Differential differential;
        [SerializeField] private Steering steering;
        [SerializeField] private Brakes breake;


        [SerializeField] private float wheelRpmLimit;
        [SerializeField] private float torqueToWheel;


        private float verticalInput;
        private float horizontalInput;


        public Engine ENGINE { get => engine; }
        public Transmission TRANSMISSION { get => transmission; }


        private void Awake()
        {
        }


        private void Update()
        {

            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transmission.UpShift();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                transmission.DownShift();
            }
        }

        private void FixedUpdate()
        {

            KPH = rigidbody.velocity.magnitude * 3.6f;
            steering.CarSpeed = KPH;

            breake.ApplyBrake(verticalInput);
            steering.SteerWheels(horizontalInput);

            engine.Process(verticalInput, transmission.RPM);
            transmission.Process(engine.TORQUE);
            differential.Process(transmission.TORQUE);

            CalculateWheelRpmLimit();
            CalculateTorqueToWheel();

            differential.ApplyTorqueToWheels(torqueToWheel);
            transmission.UpdateRpm(differential.RPM);
        }

        private void CalculateWheelRpmLimit()
        {
            float engineRpm = engine.RPM;
            if (verticalInput < 0.1f)
            {
                engineRpm = engine.IdleRPM;
            }
            wheelRpmLimit = (engineRpm / transmission.CurrentGearRatio) / differential.GearRatio;
        }

        private void CalculateTorqueToWheel()
        {
            torqueToWheel = differential.TORQUE;
            if (Mathf.Abs(differential.WheelsRpm) > Mathf.Abs(wheelRpmLimit))
            {
                torqueToWheel = 0;
            }
        }
    }
}