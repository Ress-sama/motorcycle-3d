using UnityEngine;

namespace DefaultNamespace
{
    public class Wheel : MonoBehaviour
    {

        //Angular velocity= (2*pi*rpm)/60
        //av*60 = 2*pi*rpm
        //rpm = av*60/2*pi

        private Rigidbody rigidbody;
        public float toruqe;
        public float DifferentialRPM { get; set; }

        [SerializeField] private ForceMode mode;

        [SerializeField] private float maxAngularVelocity;
        public float RPM;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

        }

        private void FixedUpdate()
        {
            maxAngularVelocity = (2 * Mathf.PI * DifferentialRPM) / 60;
            rigidbody.maxAngularVelocity = maxAngularVelocity;
            rigidbody.AddRelativeTorque(-Vector3.up * toruqe, mode);
            CalculateRpm();
        }

        private void CalculateRpm()
        {
            RPM = (rigidbody.angularVelocity.magnitude * 60) / (2 * Mathf.PI);
        }

        private void SetMaxRpm(float maxRpm)
        {

        }

    }
}