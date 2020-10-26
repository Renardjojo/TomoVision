using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class RxObject : MonoBehaviour
{
    EventSystem eventSystem;
    OutlineEffect outlineEffect;

    public UnityEvent OnElemCombinSuccess;

    public bool isHiden = true;

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

        Hide(true);
    }

    public GameObject lastSelectedGameObject;
    private GameObject currentSelectedGameObject_Recent;

    private void GetLastGameObjectSelected() {
            if (eventSystem.currentSelectedGameObject != currentSelectedGameObject_Recent) {
                lastSelectedGameObject = currentSelectedGameObject_Recent;
                currentSelectedGameObject_Recent = eventSystem.currentSelectedGameObject;
            }
    }

    void Update()
    {
        GetLastGameObjectSelected();
    }

    public void OnPointerDown()
    {
        if (tag == lastSelectedGameObject.tag)
        {
            lastSelectedGameObject.GetComponent<Item>().ValidItem();
            
            for (int i = 0; i < transform.parent.parent.childCount; i++)
            {
                for (int j = 0; j < transform.parent.parent.GetChild(i).childCount; j++)
                {
                    /*Fucking game jam, asshole code*/
                    if (transform.parent.parent.GetChild(i).GetChild(j).tag == tag)
                    {
                        transform.parent.parent.GetChild(i).GetChild(j).gameObject.SetActive(true);
                        transform.parent.parent.GetChild(i).GetChild(j).GetComponent<RxObject>()?.Hide(false);
                        //transform.parent.parent.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
            
            Hide(false);

            OnElemCombinSuccess?.Invoke();
        }
    }

    public void Hide(bool bFlag)
    {
        if (bFlag)
        {
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            Debug.Log(GetComponent<Image>().color.ToString());
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
