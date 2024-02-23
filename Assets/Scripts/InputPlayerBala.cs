using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerBala : MonoBehaviour
{
    Disparo d_Stack;

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
            bala.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bala.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 5f, 5f), ForceMode.Impulse);
        }
    }
}
