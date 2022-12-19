using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    // float smooth = 0.1f;

    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = Vector3.Lerp(transform.position, this.objectToFollow.transform.position + new Vector3(0, 0, -10), Time.deltaTime);
    // }

    void LateUpdate()
    {
        transform.position = this.objectToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
