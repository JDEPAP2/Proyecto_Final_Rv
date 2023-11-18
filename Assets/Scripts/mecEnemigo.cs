using UnityEngine;

public class mecEnemigo : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capaJugador;
    public Transform jugador;
    public float velocidad;
    public Animator a;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprueba si el jugador está en el rango de alerta
        if (Physics.CheckSphere(transform.position, rangoAlerta, capaJugador))
        {
            // Ajusta la rotación para mirar hacia el jugador
            transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));

            // Utiliza Rigidbody para mover suavemente al personaje
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime));

            // Activa la animación de caminar
            a.SetBool("Caminando", true);
        }
        else
        {
            // Desactiva la animación de caminar
            a.SetBool("Caminando", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }
}

