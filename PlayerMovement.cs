using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float RunMultiplier = 1.8f;

    public float RollSpeed = 15f;
    public float RollTime = 0.2f;

    private float RollTimer = 0f;
    private bool IsRolling = false;

    // Cooldown between rolls
    public float RollCooldown = 0.5f;
    private float RollCooldownTimer = 0f;

    private Vector3 MoveDir;

    void Update()
    {
        // Get input
        float X = 0f;
        float Y = 0f;

        if (Input.GetKey(KeyCode.A)) X = -1f;
        if (Input.GetKey(KeyCode.D)) X = 1f;
        if (Input.GetKey(KeyCode.W)) Y = 1f;
        if (Input.GetKey(KeyCode.S)) Y = -1f;

        MoveDir = new Vector3(X, Y, 0f);

        // Decrease roll cooldown timer
        if (RollCooldownTimer > 0f)
        {
            RollCooldownTimer -= Time.deltaTime;
        }

        // Start roll if cooldown finished
        if (Input.GetKeyDown(KeyCode.Space) && !IsRolling && RollCooldownTimer <= 0f)
        {
            IsRolling = true;
            RollTimer = RollTime;
            RollCooldownTimer = RollCooldown;
        }
    }

    void FixedUpdate()
    {
        // If rolling
        if (IsRolling)
        {
            RollTimer -= Time.fixedDeltaTime; 

            transform.position += MoveDir.normalized * RollSpeed * Time.fixedDeltaTime;

            if (RollTimer <= 0)
            {
                IsRolling = false;
            }

            return; // stop normal movement while rolling
        }

        // Running check
        bool IsRunning = Input.GetKey(KeyCode.LeftShift);

        float CurrentSpeed = Speed;

        if (IsRunning)
        {
            CurrentSpeed *= RunMultiplier;
        }

        // Move player
        if (MoveDir != Vector3.zero)
        {
            transform.position += MoveDir.normalized * CurrentSpeed * Time.fixedDeltaTime;
        }
    }
}