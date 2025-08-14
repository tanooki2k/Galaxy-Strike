using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;
    
    private bool _isFiring;
    private StartPlaying _startPlaying;
    
    void Start()
    {
        Cursor.visible = false;
        _startPlaying = GetComponent<StartPlaying>();
        DisableLasers();

    }

    void Update()
    {
        MoveCrosshair();
        if (_startPlaying.isEnabled)
        {
            ProcessFiring();
            MoveTargetPoint();
            AimLasers();
        }
    }

    public void OnFire(InputValue value)
    {
        if (_startPlaying.isEnabled)
        {
            _isFiring = value.isPressed;
        }
    }

    private void DisableLasers()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
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

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
