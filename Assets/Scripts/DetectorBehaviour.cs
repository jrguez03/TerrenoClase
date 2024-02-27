using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DetectorBehaviour : MonoBehaviour
{
    Disparo d_Stack2;

    [SerializeField] GameObject dc_Canon3;
    [SerializeField] GameObject dc_Canon4;

    public float dc_Fuerza = 50f;

    Vector3 dc_Impulso;

    // Start is called before the first frame update
    void Start()
    {
        dc_Impulso = Vector3.forward * dc_Fuerza;
    }

    void Awake()
    {
        d_Stack2 = GetComponent<Disparo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject bala3 = d_Stack2.ObtenerObjeto2();
            GameObject bala4 = d_Stack2.ObtenerObjeto2();
            bala3.transform.position = dc_Canon3.transform.position;
            bala4.transform.position = dc_Canon4.transform.position;
            bala3.GetComponent<Rigidbody>().velocity = transform.forward * dc_Fuerza;
            bala4.GetComponent<Rigidbody>().velocity = transform.forward * dc_Fuerza;
            bala3.GetComponent<Rigidbody>().AddForce(dc_Impulso * Time.deltaTime, ForceMode.Impulse);
            bala4.GetComponent<Rigidbody>().AddForce(dc_Impulso * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
