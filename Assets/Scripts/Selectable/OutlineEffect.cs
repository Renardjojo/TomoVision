using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
 using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class OutlineEffect : MonoBehaviour
{
    protected Image image;

    protected void Awake()
    {
       image = GetComponent<Image>();
       image.material = new Material(image.material);
    }

    protected void Start()
    {}

    void Update()
    {}

    public void SetOutlineEnable(bool bNewFlag)
    {
        if (bNewFlag)
        {
            image.material.SetFloat("_OutlineEnabled", 1f);
        }
        else
        {
            image.material.SetFloat("_OutlineEnabled", 0f);
        }
    }

    public void SetOutlineThickness(float NewThickness)
    {
        image.material.SetFloat("_Thickness", NewThickness);
    }

    public void SetOutlineColor(Color NewColor)
    {
        image.material.SetColor("_SolidOutline", NewColor);
    }
}
