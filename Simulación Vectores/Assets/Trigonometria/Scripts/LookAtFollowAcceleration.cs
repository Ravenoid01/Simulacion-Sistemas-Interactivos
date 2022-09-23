using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFollowAcceleration : MonoBehaviour
{
    private Vector2 velocity;
    private Vector2 acceleration;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPosition = GetWorldMousePosition();
        Vector2 thisPosition = transform.position;

        Vector3 direction = (mouseWorldPosition - thisPosition).normalized;

        acceleration = mouseWorldPosition - thisPosition;

        velocity += acceleration * Time.deltaTime;

        LookAtMouse(thisPosition + velocity);

        Vector3 finalPosition = new Vector3(velocity.x, velocity.y, 0);
        transform.position += finalPosition * Time.deltaTime;

    }
    private void LookAtMouse(Vector2 targetPosition)
    {
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = targetPosition - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / 2f;
        RotateZ(radians);
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
