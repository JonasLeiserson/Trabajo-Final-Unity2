using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject Bala;
    private Rigidbody RigidbodyBala;
    public int BalasEnRecamara = 6;
    private bool Cargando = false;
    private Coroutine Corutina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && BalasEnRecamara > 0 && !Cargando)
        {
            BalasEnRecamara--;
            GameObject Balaclon = Instantiate(Bala, transform.position, transform.rotation);
            Balaclon.transform.LookAt(Camera.main.transform);
            RigidbodyBala = Balaclon.GetComponent<Rigidbody>();
            RigidbodyBala.AddForce(transform.right * 30f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R) && !Cargando)
        {
            Cargando = true;
            Corutina = StartCoroutine(CargarBalas());
        }
    }
    IEnumerator CargarBalas()
    {
        while(true)
        {
            if (BalasEnRecamara == 6)
            {
                StopCoroutine(Corutina);
                Cargando = false;
            }
            yield return new WaitForSeconds(0.7f);
            BalasEnRecamara++;
        }
    }
}
;