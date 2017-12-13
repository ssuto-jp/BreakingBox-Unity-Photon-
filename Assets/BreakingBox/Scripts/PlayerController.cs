using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 5f;
    private float moveX = 0f;
    private float moveZ = 0f;
    private const string key_isRun = "isRun";
    private const string key_isAttack = "isAttack";
    Rigidbody rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        moveZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        if (direction.magnitude > 0.01f
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            float step = rotateSpeed * Time.deltaTime;
            Quaternion quaternion = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, step);
            anim.SetBool(key_isRun, true);
        }
        else
        {
            anim.SetBool(key_isRun, false);
        }

        PerformAttack();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, moveZ);
    }

    private void PerformAttack()
    {
        if (Input.GetButtonDown("Fire1") && !anim.IsInTransition(0))
        {
            anim.SetBool(key_isAttack, true);
        }
    }
}
