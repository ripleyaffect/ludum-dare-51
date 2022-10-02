using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private PlayerSpriteController spriteController;

    private Vector2 _moveDirection;

    private Vector3 _currentVelocity;

    public void SetMoveDirection(Vector2 newMoveDirection)
    {
        _moveDirection = newMoveDirection;

        // World's worst animation system
        if (_moveDirection.magnitude > 0.05f)
            spriteController.Run();
        else spriteController.Stand();

        switch (_moveDirection.x)
        {
            case > 0.05f:
                spriteController.SetFlipX(false);
                break;
            case < -0.05f:
                spriteController.SetFlipX(true);
                break;
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = GetNextVelocity(rb.velocity, Time.fixedDeltaTime);
    }

    private Vector3 GetNextVelocity(Vector3 currentVelocity, float deltaTime)
    {
        var targetVelocity = new Vector3(_moveDirection.x, 0f, _moveDirection.y) * maxSpeed;
        return Vector3.Lerp(currentVelocity, targetVelocity, acceleration * deltaTime);
    }
}
