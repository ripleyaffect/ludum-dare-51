using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private PlayerInputActions _playerInputActions;

    private void OnMove(InputAction.CallbackContext context)
    {
        playerController.SetMoveDirection(context.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        // Instantiate if needed
        _playerInputActions ??= new PlayerInputActions();

        // Subscribe to input events
        _playerInputActions.Default.Move.started += OnMove;
        _playerInputActions.Default.Move.performed += OnMove;
        _playerInputActions.Default.Move.canceled += OnMove;

        _playerInputActions.Default.Enable();
    }


    private void OnDisable()
    {
        _playerInputActions.Default.Disable();

        // Unsubscribe from input events
        _playerInputActions.Default.Move.started -= OnMove;
        _playerInputActions.Default.Move.performed -= OnMove;
        _playerInputActions.Default.Move.canceled -= OnMove;

    }

}
