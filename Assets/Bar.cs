using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : Slider
{
    [SerializeField]
    Text percentage;
    [SerializeField]
    Text textValue;

    protected override void Start()
    {
        base.Start();
        onValueChanged.AddListener(delegate { UpdateTextValue(); });
    }

    void UpdateTextValue()
    {
        textValue.text = value.ToString();
        percentage.text = string.Format("{0:P2}",(float)value / (float)maxValue);
    }
}
