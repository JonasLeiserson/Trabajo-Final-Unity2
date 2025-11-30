using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Colision : MonoBehaviour
{
    public float vidaEscorpion = 100f;
    public Transform targetJugador;
    public float distanciaDeteccion = 5f;
    public float velocidadAtaque = 0.5f;

    private Animator anim;
    private NavMeshAgent agente;
    private float cooldownAtaque = 1f;
    private float tiempoProximoAtaque = 0f;
    private float velocidadNormal;
    private const float DANO_ATAQUE_ESCORPION = 10f;

    void Start()
    {
        targetJugador = GameObject.FindGameObjectWithTag("Player").transform;
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Velocidad", 5.1f);
        anim.SetFloat("Vida", vidaEscorpion);
        velocidadNormal = agente.speed;
    }

    void Update()
    {
        if (targetJugador == null) return;

        Vector3 direccionAlJugador = targetJugador.position - transform.position;
        Ray rayo = new Ray(transform.position, direccionAlJugador.normalized);
        Debug.DrawRay(transform.position, direccionAlJugador.normalized * distanciaDeteccion, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, distanciaDeteccion))
        {
            if (hit.collider.CompareTag("Player"))
            {
                anim.SetFloat("DistanciaJugador", 4);
                agente.speed = velocidadAtaque;
                Ataque();
            }
            else
            {
                anim.SetFloat("DistanciaJugador", 5);
                agente.speed = velocidadNormal;
            }
        }
        else
        {
            anim.SetFloat("DistanciaJugador", 5);
            agente.speed = velocidadNormal;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            Destroy(other.gameObject);
            vidaEscorpion -= 25f;
            anim.SetFloat("Vida", vidaEscorpion);

            if (vidaEscorpion <= 0f)
            {
                anim.SetFloat("Velocidad", 1f);
                agente.velocity = Vector3.zero;
                StartCoroutine(Muriendo());
            }
        }
    }

    private void Ataque()
    {
        if (Time.time >= tiempoProximoAtaque)
        {
            tiempoProximoAtaque = Time.time + cooldownAtaque;

            if (VidaJugador.Instance != null)
            {
                VidaJugador.Instance.RecibirDaño(DANO_ATAQUE_ESCORPION);
            }
        }
    }

    IEnumerator Muriendo()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}