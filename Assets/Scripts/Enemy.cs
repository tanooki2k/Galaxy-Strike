using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
