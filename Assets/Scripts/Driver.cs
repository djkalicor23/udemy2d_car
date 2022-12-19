// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerSpeed = 100;
    float moveSpeed = 20f;
    float normalSpeed = 20f;
    float fastSpeed = 30f;
    float slowSpeed = 10f;

    float speedCountdown = 2f;
    float speedCountdownRemain;

    void Start()
    {
    }

    void Update()
    {
        float delta = Time.deltaTime;
        Debug.Log(Input.GetAxis("Vertical"));
        float steerDirection = Input.GetAxis("Vertical") < 0 ? -1 : 1;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * delta;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * delta * steerDirection;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if(speedCountdownRemain > 0) {
            speedCountdownRemain -= Time.deltaTime;
            if(speedCountdownRemain <= 0) {
                moveSpeed = normalSpeed;
                speedCountdownRemain = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        speedChange(slowSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        switch(other.tag) {
            case "SpeedUp": {
                speedChange(fastSpeed);
                break;
            }

            case "SpeedDown": {
                speedChange(slowSpeed);
                break;
            }
        }
    }

    private void speedChange(float targetSpeed) {
        moveSpeed = targetSpeed;
        speedCountdownRemain = speedCountdown;
    }
}
