using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Velocidad", 5f);
        anim.SetFloat("Vida", 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
