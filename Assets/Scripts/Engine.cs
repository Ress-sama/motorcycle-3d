using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Engine : MonoBehaviour
    {
        [SerializeField] private AnimationCurve Torque;

        public float IncraseSpeed;
        public float IdleRPM;
        public float MaxRPM;
        public float TORQUE;
        public float RPM;

        private void Awake()
        {
            MaxRPM = Torque.keys[Torque.keys.Length - 1].time;
        }

        public void Process(float throttle, float transmissionRpm)
        {
            float velocity = 0;
            RPM = Mathf.SmoothDamp(RPM, IdleRPM + transmissionRpm, ref velocity, IncraseSpeed);
            if (RPM > MaxRPM)
            {
                RPM = MaxRPM;
            }
            if (RPM < IdleRPM)
            {
                RPM = IdleRPM;
            }
            TORQUE = Torque.Evaluate(RPM) * throttle;

            if (throttle<0.1f)
            {
                TORQUE = Torque.Evaluate(IdleRPM);
            }
        }
    }
}