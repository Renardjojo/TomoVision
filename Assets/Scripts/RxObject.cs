using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
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

        Hide(true);
    }

    public void Hide(bool bFlag)
    {
        if (bFlag)
        {
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (tag == eventData.lastPress.tag)
        {
            eventData.lastPress.GetComponent<Item>().ValidItem();
            Hide(false);

            OnElemCombinSuccess?.Invoke();
        }
    }
}
