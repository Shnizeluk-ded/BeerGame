using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

    private const float MOVE_SPEED = 60f;

    private enum State {
        Normal,
        Rolling,
    }

    [SerializeField] private LayerMask dashLayerMask;

    
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private Vector3 rollDir;
    private Vector3 lastMoveDir;
    private float rollSpeed;
    private bool isDashButtonDown;
    private State state;
    public float speed;

    private void Awake() {
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }

    private void Update() {
        switch (state) {
        case State.Normal:
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W)) {
                moveY = +speed;
            }
            if (Input.GetKey(KeyCode.S)) {
                moveY = -speed;
            }
            if (Input.GetKey(KeyCode.A)) {
                moveX = -speed;
            }
            if (Input.GetKey(KeyCode.D)) {
                moveX = +speed;
            }

            moveDir = new Vector3(moveX, moveY).normalized;
            if (moveX != 0 || moveY != 0) {
                // Not idle
                lastMoveDir = moveDir;
            }
            

            if (Input.GetKeyDown(KeyCode.F)) {
                isDashButtonDown = true;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                rollDir = lastMoveDir;
                rollSpeed = 250f;
                state = State.Rolling;
                
            }
            break;
        case State.Rolling:
            float rollSpeedDropMultiplier = 5f;
            rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

            float rollSpeedMinimum = 50f;
            if (rollSpeed < rollSpeedMinimum) {
                state = State.Normal;
            }
            break;
        }
    }

    private void FixedUpdate() {
        switch (state) {
        case State.Normal:
            rigidbody2D.linearVelocity = moveDir * MOVE_SPEED;

            if (isDashButtonDown) {
                float dashAmount = 50f;
                Vector3 dashPosition = transform.position + lastMoveDir * dashAmount;

                RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDir, dashAmount, dashLayerMask);
                if (raycastHit2d.collider != null) {
                    dashPosition = raycastHit2d.point;
                }

                
                

                rigidbody2D.MovePosition(dashPosition);
                isDashButtonDown = false;
            }
            break;
        case State.Rolling:
            rigidbody2D.linearVelocity = rollDir * rollSpeed;
            break;
        }
    }

}
