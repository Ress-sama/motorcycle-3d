using UnityEngine;

namespace DefaultNamespace
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private WheelCollider wheelCollider;
        [SerializeField] private float rpm;

        public void Turn(float torque)
        {
            rpm = wheelCollider.rpm;
            wheelCollider.motorTorque = torque;
        }
    }
}