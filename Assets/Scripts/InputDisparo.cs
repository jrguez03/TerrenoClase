using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDisparo : MonoBehaviour
{
    Disparo d_Stack;

    [SerializeField] GameObject p_Canon;
    [SerializeField] GameObject p_Canon2;

    public float d_Fuerza = 50f;
    public float d_MinFuerza = 50f;
    public float d_MaxFuerza = 150f;
    public float d_AceleracionFuerza = 10f;

    Vector3 d_Impulso;
    // Start is called before the first frame update
    void Start()
    {
        //Vectores para el disparo.
        d_Impulso = Vector3.forward * d_Fuerza;
    }

    void Awake()
    {
        d_Stack = GetComponent<Disparo>();
    }

    // Update is called once per frame
    void Update()
    {
        //Aceleración y frenado.
        if (Input.GetKey(KeyCode.W))
        {
            d_Fuerza += d_AceleracionFuerza * Time.deltaTime;

            if (d_Fuerza >= d_MaxFuerza)
            {
                d_Fuerza = d_MaxFuerza;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            d_Fuerza -= d_AceleracionFuerza * Time.deltaTime;

            if (d_Fuerza <= d_MinFuerza)
            {
                d_Fuerza = d_MinFuerza;
            }
        }

        //Inptu Disparo del jugador
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bala = d_Stack.ObtenerObjeto();
            GameObject bala2 = d_Stack.ObtenerObjeto();
            bala.transform.position = p_Canon.transform.position;
            bala2.transform.position = p_Canon2.transform.position;
            bala.GetComponent<Rigidbody>().velocity = p_Canon.transform.forward * d_Fuerza;
            bala2.GetComponent<Rigidbody>().velocity = p_Canon2.transform.forward * d_Fuerza;
            bala.GetComponent<Rigidbody>().AddForce(d_Impulso * Time.deltaTime, ForceMode.Impulse);
            bala2.GetComponent<Rigidbody>().AddForce(d_Impulso * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
