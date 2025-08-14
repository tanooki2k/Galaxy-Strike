using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    
    private int _score;

    private void Start()
    {
        scoreboardText.text = $"Score: {_score:D6}";
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        scoreboardText.text = $"Score: {_score:D6}";
    }
}
