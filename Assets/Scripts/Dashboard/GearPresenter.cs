using Riyezu.CarSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearPresenter : MonoBehaviour
{

    [SerializeField] Transmission transmission;
    [SerializeField] Text gearText;
    void Update()
    {
        if (transmission.CurrentGear == 0)
        {
            gearText.text = "R";
        }
        else if (transmission.CurrentGear == 1)
        {
            gearText.text = "N";
        }
        else
        {
            gearText.text = (transmission.CurrentGear - 1).ToString();
        }
    }
}
