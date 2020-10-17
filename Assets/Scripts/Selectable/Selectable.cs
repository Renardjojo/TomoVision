using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
 using UnityEngine.EventSystems;
using UnityEngine;

public class Selectable : MonoBehaviour, IDeselectHandler, ISelectHandler
{
    protected Image image;
    protected bool bIsSelected = false;

    // Start is called before the first frame update
    protected void Awake()
    {
       image = GetComponent<Image>();
       image.material = new Material(image.material);
    }

    protected void Start()
    {
        image.alphaHitTestMinimumThreshold = 0.5f;
    }

    void Update()
    {}
    public void Select()
    {
        bIsSelected = true;
        SetOutlineEnable(true);
    }

    public void Unselect()
    {
        bIsSelected = false;
        SetOutlineEnable(false);
    }

    public void SwitchSelectionState()
    {
        bIsSelected = !bIsSelected;
        SetOutlineEnable(bIsSelected);
    }

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

    public void OnSelect(BaseEventData eventData)
    {
        Select();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Unselect();
    }
}
