using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private ActionController actionController;
    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        actionController = new ActionController();

        _instance = this;
    }

    private void OnEnable()
    {
        actionController.Enable();
    }

    private void OnDisable()
    {
        actionController.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return actionController.Player.Movement.ReadValue<Vector2>();
    }

    public bool PlayerShot()
    {
        return actionController.Player.Shoot.triggered;
    }
}
