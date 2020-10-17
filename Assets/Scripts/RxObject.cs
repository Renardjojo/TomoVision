using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
 using UnityEngine.Events;
using UnityEngine;

public class RxObject : MonoBehaviour, IPointerDownHandler
{
    EventSystem eventSystem;
    OutlineEffect outlineEffect;

    public UnityEvent OnElemCombinSuccess;

    void Awake()
    {
        outlineEffect = GetComponent<OutlineEffect>();
    }

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        if (eventSystem == null)
        {
            Debug.Log("echec");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject.tag == eventData.lastPress.tag)
        {
            eventData.lastPress.SetActive(false);
            eventData.selectedObject.SetActive(false);

            OnElemCombinSuccess?.Invoke();
        }
    }
}
