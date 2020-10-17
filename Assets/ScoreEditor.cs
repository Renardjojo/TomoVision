using UnityEngine.UI;
using UnityEngine;

public class ScoreEditor : MonoBehaviour
{
    protected Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText(uint NewScore, uint MaxScore)
    {    
        text.text = NewScore.ToString() + " / " + MaxScore.ToString();
    }
}
