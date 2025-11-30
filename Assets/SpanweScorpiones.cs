using System.Collections;
using UnityEngine;

public class SpanweScorpiones : MonoBehaviour
{
    public GameObject prefabEscorpion;
    public float tiempoEntreSpawn = 10f;
    public float alturaMaxRaycast = 50f;

    private BoxCollider areaSpawn;

    void Start()
    {
        areaSpawn = GetComponent<BoxCollider>();

        if (areaSpawn == null)
        {
            Debug.LogError("Se requiere un BoxCollider en este GameObject para SpanweScorpiones.");
            return;
        }

        if (prefabEscorpion == null)
        {
            Debug.LogError("Asigna el Prefab del Escorpión en el Inspector.");
            return;
        }

        StartCoroutine(RutinaSpawn());
    }

    IEnumerator RutinaSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreSpawn);
            SpawnearEscorpion();
        }
    }

    void SpawnearEscorpion()
    {
        Bounds bounds = areaSpawn.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 puntoSuperior = new Vector3(randomX, bounds.center.y + (bounds.size.y / 2f) + 1f, randomZ);

        RaycastHit hit;

        if (Physics.Raycast(puntoSuperior, Vector3.down, out hit, alturaMaxRaycast))
        {
            Vector3 posicionSpawn = hit.point;
            Instantiate(prefabEscorpion, posicionSpawn, Quaternion.identity);
        }
    }
}