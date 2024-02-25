using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBar : MonoBehaviour
{
    [SerializeField] FloatVariable statVariable;
    [SerializeField] EventListener updateEvent;

    [SerializeField] Slider slider;

    public void OnUpdateSlider()
    {
        slider.value = statVariable.value / 40;
    }
}
