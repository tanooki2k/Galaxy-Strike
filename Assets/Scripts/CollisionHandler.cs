using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;

    private StartPlaying _startPlaying;
    private GameSceneManager _gameSceneManager;

    private void Start()
    {
        _startPlaying = GetComponent<StartPlaying>();
        _gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (_startPlaying.isEnabled)
        {
            DestroyGameObject();
        }
    }

    private void DestroyGameObject()
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        _gameSceneManager.ReloadLevel();
    }
}
