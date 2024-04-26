using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testScript : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;

    private Rigidbody rb;
    private GameController gameController;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private bool stopped = false;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) {
        jumped = context.action.triggered;
    }

    public void OnStop(InputAction.CallbackContext context) {
        stopped = context.action.triggered;
    }

    void FixedUpdate() {
        //groundedPlayer = controller.isGrounded;
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y) * playerSpeed;
        if (move != Vector3.zero) {
            //gameObject.transform.forward = move;
        }

        if (!stopped) { //if player is holding the stop button, do none of the physics calculations
            rb.AddForce(move);

            //changes the height position of the player
            if (jumped && groundedPlayer)
            {
                rb.AddForce(0, jumpHeight, 0);
            }

            if (transform.position.y < -10) { //check if below certain y position
                reset();
            }
        } else {
            rb.Sleep();
        }
    }

    void reset() {
        gameController.resetPlayer(this.gameObject);
    }
}
