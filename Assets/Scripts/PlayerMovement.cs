using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] Vector2 screenCenterOffset;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 2f;
    
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
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * _movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}