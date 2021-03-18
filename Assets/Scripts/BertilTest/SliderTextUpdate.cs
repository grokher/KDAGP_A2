using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextUpdate : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "" + this.gameObject.GetComponent<Slider>().value;
    }
}
