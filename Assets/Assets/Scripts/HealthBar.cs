using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    
    //sets the max health as teh value on the slider and then sets the slider length to the leath
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //sets the visuals for the health bar
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
