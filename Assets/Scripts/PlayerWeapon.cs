using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    
    bool _isFiring;

    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
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

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
}
