using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    EventSystem eventSystem;

    public uint CurrentScore { get; set; }

    [SerializeField]
    protected const uint maxScore = 4;

    public UnityEvent OnLevelEnd;

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

    public uint GetMaxScore() { return maxScore; }

    public void IncreaseScore()
    {
        CurrentScore++;
        if (CurrentScore >= maxScore)
        {
            OnLevelEnd?.Invoke();
        }
    }
}

