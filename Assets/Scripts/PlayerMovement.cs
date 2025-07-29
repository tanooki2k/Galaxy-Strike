using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] Vector2 screenCenterOffset;

    [SerializeField] float controlPitchFactor = 30f;
    [SerializeField] float controlYawFactor = .1f;
    [SerializeField] float controlRollFactor = 30f;
    [SerializeField] float rotationSpeed = 8f;


    Vector2 _movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = _movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange + screenCenterOffset.x, xClampRange + screenCenterOffset.x);
        
        float yOffset = _movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange + screenCenterOffset.y, yClampRange + screenCenterOffset.y);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * _movement.y;
        float yaw =  controlYawFactor * transform.localPosition.x;
        float roll = -controlRollFactor * _movement.x;
        
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }
}