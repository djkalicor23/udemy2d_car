// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerSpeed = 100;
    float moveSpeed = 20;
    void Start()
    {
    }

    void Update()
    {
        float delta = Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * delta;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * delta;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
