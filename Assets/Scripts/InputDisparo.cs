using UnityEngine;

public class InputDisparo : MonoBehaviour
{
    Disparo d_Stack;
    BombPool b_Stack;

    [SerializeField] GameObject p_Canon;
    [SerializeField] GameObject p_Canon2;
    [SerializeField] GameObject p_Canon3;

    [SerializeField] AudioSource d_Source;

    public float d_Fuerza = 70f;
    public float d_MinFuerza = 70f;
    public float d_MaxFuerza = 120f;
    public float d_AceleracionFuerza = 20f;

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
        b_Stack = GetComponent<BombPool>();
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

            d_Source.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bomba = b_Stack.ObtenerObjeto();

            bomba.transform.position = p_Canon3.transform.position;
        }
    }
}
