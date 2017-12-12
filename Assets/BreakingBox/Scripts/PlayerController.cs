using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 5f;
    private float moveX = 0f;
    private float moveZ = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        moveZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        if (direction.magnitude > 0.01f)
        {
            float step = rotateSpeed * Time.deltaTime;
            Quaternion quaternion = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, step);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
