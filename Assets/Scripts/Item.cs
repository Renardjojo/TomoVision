using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManager gameManager;

    ScoreEditor scoreEditor;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreEditor = GameObject.Find("ScoreEditor").GetComponent<ScoreEditor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidItem()
    {
        IncreaseScore();
        GetComponent<Image>().color = Color.green;
        GetComponent<Button>().interactable = false;
    }

    public void IncreaseScore()
    {
        gameManager.IncreaseScore();
        scoreEditor.UpdateScoreText(gameManager.CurrentScore, gameManager.GetMaxScore());
    }
}
