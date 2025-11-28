using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarArma : MonoBehaviour
{
    public bool PistolaAgarrada = false;
    public Transform camara;
    public float distancia = 3f;
    public Disparar disparar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
            Ray rayo = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        RaycastHit hit;

            if (Physics.Raycast(rayo, out hit, distancia))
            {
                if (hit.collider.CompareTag("Arma"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        EquiparPistola();
                    }
                }
            }
    }
    private void EquiparPistola()
    {
        transform.SetParent(camara);
        transform.localPosition = new Vector3(0.55f, -0.35f, 1.2f);
        transform.localRotation = Quaternion.Euler(0, -95, 0);
        AgarrarArma agarrarArma = this;
        agarrarArma.enabled = false;
        disparar.enabled = true;

    }
}
