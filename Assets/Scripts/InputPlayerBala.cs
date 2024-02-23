using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerBala : MonoBehaviour
{
    Disparo d_Stack;
    public float d_Fuerza = 10f;
    Vector3 d_Impulso;

    private void Start()
    {
        d_Impulso = Vector3.forward * d_Fuerza;
    }
    void Awake()
    {
        d_Stack = GetComponent<Disparo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bala = d_Stack.ObtenerObjeto();
            bala.transform.position = transform.position;
            bala.GetComponent<Rigidbody>().velocity = d_Impulso;
            bala.GetComponent<Rigidbody>().AddForce(d_Impulso * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
