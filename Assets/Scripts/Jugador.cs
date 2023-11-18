using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadM = 5.0f;
    public float velocidadR = 200.0f;
    public float x, y;

    // Eliminamos la variable Animator si no se usa
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadR, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadM);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Eliminamos el bloque relacionado con saltar y bailar

        // Mantenemos la lógica de movimiento solo con las teclas AWSD
    }
}

