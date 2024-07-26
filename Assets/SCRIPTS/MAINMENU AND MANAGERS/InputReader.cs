using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction fireAction;

    public Vector2 Move => moveAction.ReadValue<Vector2>();
    public bool Fire => fireAction.ReadValue<float>() > 0f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        fireAction = playerInput.actions["Fire"];
    }
}


