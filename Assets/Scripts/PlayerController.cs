using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller;
    private Player player;
    private InputManager inputManager;
    private Gun equippedGun;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform camTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        equippedGun = GetComponent<Gun>();
        camTransform = Camera.main.transform;
        inputManager = InputManager.Instance;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(player.IsDead) return;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;

        Vector3 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x , 0, movement.y);
        move = camTransform.forward * move.z + camTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (inputManager.PlayerShot()) 
        {
            if(equippedGun != null) equippedGun.Shoot();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
