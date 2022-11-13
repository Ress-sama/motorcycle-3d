using Riyezu.CarSystem;
using UnityEngine;
using UnityEngine.UI;
namespace Riyezu.Dashboard
{
    public class Speedometer : MonoBehaviour
    {
        [SerializeField] private Text speedUIText;
        [SerializeField] private Vehicle vehicle;

        private void Update()
        {
            speedUIText.text = ((int)vehicle.KPH).ToString();
        }
    }
}
