using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        // Update UI score display here
    }
}
