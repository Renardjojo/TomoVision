using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class InputController : MonoBehaviour
{
    [SerializeField]
    LayerMask layerValidForSelection = 128;

    Selectable currentObjectSelected = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {      
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, layerValidForSelection);

            if (rayHit)
            {
                if (currentObjectSelected != null)
                {
                    currentObjectSelected.Unselect();
                }

                currentObjectSelected = rayHit.transform.gameObject.GetComponent<Selectable>();
                currentObjectSelected.Select();
            }
            else if (currentObjectSelected != null)
            {
                currentObjectSelected.Unselect();
                currentObjectSelected = null;
            }
        } 
    }
}
