using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TomoController : MonoBehaviour
{
    int direction = 0;

    [SerializeField]
    public GameObject TomoViewObject;

    public Button RightButtonObject;
    public Button LeftButtonObject;

    public float WaitDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunStarting());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnLeft()
    {
        TomoViewObject.transform.GetChild(direction).gameObject.SetActive(false);
        direction++;
        
        if (direction >= TomoViewObject.transform.childCount)
        {
            direction = 0;
        }

        TomoViewObject.transform.GetChild(direction).gameObject.SetActive(true);
    }

    public void TurnRight()
    {
        TomoViewObject.transform.GetChild(direction).gameObject.SetActive(false);
        direction--;

        if (direction < 0)
        {
            direction = TomoViewObject.transform.childCount - 1;
        }

        TomoViewObject.transform.GetChild(direction).gameObject.SetActive(true);
    }

    IEnumerator RunStarting()
    {
        int index = 0; 
        
        RightButtonObject.interactable = false;
        LeftButtonObject.interactable = false;

        while(index < 4)
        {
            index++;
            yield return new WaitForSeconds(WaitDuration);
            TurnRight();
        }

        RightButtonObject.interactable = true;
        LeftButtonObject.interactable = true;

    }
}
