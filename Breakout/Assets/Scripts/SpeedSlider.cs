using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public Settings settings;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = (int)settings.BallSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { HandleChanges(); });
    }

    public void HandleChanges()
    {
        settings.ChangeSpeed(slider.value);
    }
}
