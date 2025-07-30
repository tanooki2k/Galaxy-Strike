using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    
    bool _isFiring;
    
    void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue value)
    {
        _isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = _isFiring;
        }
    }
}
