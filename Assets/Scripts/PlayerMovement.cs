using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] Vector2 screenCenterOffset;

    Vector2 _movement;
    void Update()
    {
        ProcessTranslation();
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = _movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange + screenCenterOffset.x, xClampRange + screenCenterOffset.x);
        
        float yOffset = _movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange + screenCenterOffset.y, yClampRange + screenCenterOffset.y);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}