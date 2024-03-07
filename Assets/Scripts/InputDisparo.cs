using UnityEngine;
using TMPro;

public class InputDisparo : MonoBehaviour
{
    Disparo d_Stack;
    BombPool b_Stack;

    [SerializeField] GameObject p_Canon;
    [SerializeField] GameObject p_Canon2;
    [SerializeField] GameObject p_Canon3;
    [SerializeField] TextMeshProUGUI d_BalasText;

    [SerializeField] AudioSource d_Source;

    public float d_Fuerza = 70f;
    public float d_MinFuerza = 70f;
    public float d_MaxFuerza = 120f;
    public float d_AceleracionFuerza = 20f;
    public float d_CooldownBomb = 2f;
    private float d_FireTimeBomb = 0f;

    Vector3 d_Impulso;
    //Modificaciones examen:
    public float d_CooldownBala = 0.5f;
    private float d_FireTimeBala = 0f;

    public float d_NumeroBalas = 15f;
    public float d_ResetBalas = 15f;
    public float d_CooldownRecarga = 1f;
    public float d_TiempoRecargando = 2f;
    public float d_ResetTiempoRecargando = 2f;
    public float d_RecargaPlayer = 1f;
    public float d_ResetRecargaPlayer = 1f;
    bool d_CDRecarga = false;
    bool d_CDPlayer = false;
    bool d_Dispara = true;

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
        if (Input.GetButtonUp("Fire1") && Time.time > d_FireTimeBala && d_NumeroBalas >= 0f && d_Dispara == true)
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

            d_FireTimeBala = Time.time + d_CooldownBala;

            d_NumeroBalas = d_NumeroBalas - 1;
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.time > d_FireTimeBomb)
        {
            GameObject bomba = b_Stack.ObtenerObjeto();

            bomba.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            bomba.transform.position = p_Canon3.transform.position;

            d_FireTimeBomb = Time.time + d_CooldownBomb;
        }

        //Modificacion examen recargar:
        if (d_NumeroBalas <= 0f)
        {
            d_CDRecarga = true;
            d_Dispara = false;

            d_BalasText.text = "Reloading";
        }

        if (d_CDRecarga == true)
        {
            d_TiempoRecargando -= d_CooldownRecarga * Time.deltaTime;

            if (d_TiempoRecargando <= 0f)
            {
                d_NumeroBalas = d_ResetBalas;

                d_TiempoRecargando = d_ResetTiempoRecargando;

                d_CDRecarga = false;

                d_Dispara = true;
            }
        }
        //Modificacion examen recarga de jugador:
        if (Input.GetKeyDown(KeyCode.R))
        {
            d_CDPlayer = true;
            d_Dispara = false;

            d_BalasText.text = "Reloading";
        }

        if (d_CDPlayer == true)
        {
            d_RecargaPlayer -= d_CooldownRecarga * Time.deltaTime;

            if (d_RecargaPlayer <= 0f)
            {
                d_NumeroBalas = d_ResetBalas;

                d_RecargaPlayer = d_ResetRecargaPlayer;

                d_CDPlayer = false;

                d_Dispara = true;
            }
        }
        //Modificacion examen texto en pantalla del contador de balas:
        if (d_NumeroBalas > 0)
        {
            d_BalasText.text = d_NumeroBalas + "/15";
        }
    }
}
