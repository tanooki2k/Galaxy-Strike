using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }
}
