using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    public AudioSource walk;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);

        if (horizontalInput > 0 || verticalInput > 0)
        {
            walk.enabled = true;
        }
        else
        {
            walk.enabled = false;
        }
    }
}
