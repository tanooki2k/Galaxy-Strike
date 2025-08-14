using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;
    [SerializeField] private int hitPoints = 3;
    [SerializeField] private int scoreValue = 10;
    
    private ScoreBoard _scoreboard;

    private void Start()
    {
        _scoreboard = FindFirstObjectByType<ScoreBoard>();
    }
    
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            _scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
