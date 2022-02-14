using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)//Iniciar o slier com a vida ao máximo
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)//Passar para o slider a vida
    {
        slider.value = health;
    }
}
