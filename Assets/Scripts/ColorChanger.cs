using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private RawImage part;
    Color color_unselected;
    Color color_selected;
    Color pointColor = new Color(255 / 255f, 239 / 255f, 105 / 255f);

    void Awake()
    {
        part = GetComponent<RawImage>();
        color_unselected = Color.white;
        color_unselected.a = 1f;
        color_selected = pointColor;
        color_selected.a = 1f;
        part.color = color_unselected;   
    }

    public void Selected()
    {
        part.color = color_selected;
    }

    public void UnSelected()
    {
        part.color = color_unselected;
    }

}
