using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;

    private StartPlaying _startPlaying;

    private void Start()
    {
        _startPlaying = GetComponent<StartPlaying>();
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
    }
}
