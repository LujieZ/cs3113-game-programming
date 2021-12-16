using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class MySlider : MonoBehaviour
{
    public Slider slider;

    public FirstPersonController fpc;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        fpc = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>();
        slider.value  = fpc.RotationSpeed;
        slider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = fpc.RotationSpeed;
    }

    public void ValueChangeCheck()
    {
        fpc.RotationSpeed = (int)slider.value;
    }
}
