using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    public TMP_Text speedSliderTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update Value of Slider
        UpdateSliderValue();
    }

    public void UpdateSliderValue()
    {
        speedSliderTxt.text = speedSlider.value.ToString("F2");
    }

}
