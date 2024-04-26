using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float ragdollTimer = 0f;

    public Rigidbody rb;

    private CharacterController controller;
    private GameController gameController;
    private Vector3 playerVelocity;
    private Vector2 movementInput = Vector2.zero;

    private bool groundedPlayer;
    private bool jumped = false;
    private bool stopped = false;
    private bool queueReset = false;

    private void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    //unity events that are invoked as input
    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) {
        jumped = context.action.triggered;
    }

    public void OnStop(InputAction.CallbackContext context) {
        stopped = context.action.triggered;
    }

    public void OnReset(InputAction.CallbackContext context) {
        queueReset = context.action.triggered;
    }

    public void OnRagdoll(InputAction.CallbackContext context) {
        ragdoll(3);
    }

    void Update() {
        if(ragdollTimer <= 0) {
            rb.isKinematic = true;
            controller.enabled = true; //ensure the player is not ragdolled

            groundedPlayer = controller.isGrounded;
            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            if (move != Vector3.zero) { //if input is not zero, rotate the player to match forward movement
                gameObject.transform.forward = move;
            }

            if (!stopped) { //if player is holding the stop button, do none of the physics calculations
                if (groundedPlayer && playerVelocity.y < 0) {
                    playerVelocity.y = 0f;
                }

                controller.Move(move * Time.deltaTime * playerSpeed);
            
                if (jumped && groundedPlayer) { //adjusts the height of the player when they jump
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                }

                playerVelocity.y += gravityValue * Time.deltaTime;
                controller.Move(playerVelocity * Time.deltaTime);

                if (transform.position.y < -10 || queueReset) { //check if below certain y position. if yes, reset to last checkpoint
                    reset();
                    queueReset = false;
                }
            }
        } else {ragdollTimer -= Time.deltaTime;}
    }

    void reset() {
        gameController.resetPlayer(this.gameObject);
    }

    void ragdoll(float time) { //ragdolls the player for a certain amount of time in seconds
        ragdollTimer = time;
        rb.isKinematic = false;
        controller.enabled = false;
        rb.velocity = new Vector3(movementInput.x, playerVelocity.y, movementInput.y);
        Transform transform = gameObject.transform;
        rb.AddForceAtPosition(transform.forward * 10, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
        rb.AddRelativeTorque(new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f)));
    }
}
