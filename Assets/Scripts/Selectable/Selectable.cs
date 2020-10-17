using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected bool bIsSelected = false;

    // Start is called before the first frame update
    protected void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    protected void Start()
    {}

    void Update()
    {}

    public void Select()
    {
        bIsSelected = true;
        SetOutlineEnable(true);
        Debug.Log("ok");
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
            spriteRenderer.material.SetFloat("_OutlineEnabled", 1f);
        }
        else
        {
            spriteRenderer.material.SetFloat("_OutlineEnabled", 0f);
        }
    }

    public void SetOutlineThickness(float NewThickness)
    {
        spriteRenderer.material.SetFloat("_Thickness", NewThickness);
    }

    public void SetOutlineColor(Color NewColor)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);

        mpb.SetColor("_SolidOutline", NewColor);

        spriteRenderer.SetPropertyBlock(mpb);
    }

}
