using UnityEngine;
using System.Collections;

public class TomoController : MonoBehaviour
{
    int direction = 0;

    [SerializeField]
    public GameObject TomoViewObject;

    // Start is called before the first frame update
    void Start()
    {

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
}
