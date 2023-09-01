using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    Bar[] resultBars;
    private void Awake()
    {
        resultBars = GetComponentsInChildren<Bar>();
    }

    public void SetMax(int maxValue)
    {
        foreach (Slider slider in resultBars)
        {
            slider.maxValue = maxValue;
        }
    }

    public void SetValue(int barIndex, int value)
    {
        resultBars[0].value = value;
    }

    public void SetValues(int value0, int value1, int value2, int value3, int value4, int value5)
    {
        resultBars[0].value = value0;
        resultBars[1].value = value1;
        resultBars[2].value = value2;
        resultBars[3].value = value3;
        resultBars[4].value = value4;
        resultBars[5].value = value5;
    }
}
