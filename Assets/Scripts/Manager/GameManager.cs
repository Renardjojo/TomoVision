using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    EventSystem eventSystem;

    void Awake()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CheckIfItemIsValid()
    {
        Debug.Log(eventSystem.firstSelectedGameObject.gameObject.tag);


    }
}

