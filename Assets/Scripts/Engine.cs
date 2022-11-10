using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Engine : MonoBehaviour
    {
        [SerializeField] private AnimationCurve Torque;


        [SerializeField] private float IdleRPM;
        [SerializeField] private float IncraseSpeed;
        public float MaxRPM;
        public float TORQUE => Torque.Evaluate(RPM);
        public float RPM;

        private void Awake()
        {
            MaxRPM = Torque.keys[Torque.keys.Length - 1].time;
        }

        public void Process(float throttle, float transmissionRpm)
        {
            float velocity = 0;
            if (throttle <= 0.1)
            {
                RPM = IdleRPM;
            }
            RPM = Mathf.SmoothDamp(RPM, IdleRPM + transmissionRpm * throttle, ref velocity, IncraseSpeed);
            if (RPM > MaxRPM)
            {
                RPM = MaxRPM;
            }
        }
    }
}