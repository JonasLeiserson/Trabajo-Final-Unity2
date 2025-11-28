using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private Transform Jugador;
    private NavMeshAgent agente;

    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player").transform;
        agente = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agente.destination = Jugador.position;
    }
}
