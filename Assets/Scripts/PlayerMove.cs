using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Disparo d_Stack;
    [SerializeField] ParticleSystem p_Explotion;

    public float p_Speed = 20f;
    public float p_Sensitivity = 1f;
    public float p_MinSpeed = 20f;
    public float p_MaxSpeed = 120f;
    public float p_Aceleration = 10f; 
    public float d_Fuerza = 50f;
    public float d_MinFuerza = 50f;
    public float d_MaxFuerza = 150f;
    public float d_AceleracionFuerza = 10f;

    Vector2 p_turn;
    Vector3 p_Movement;
    Vector3 d_Impulso;
    // Start is called before the first frame update
    void Start()
    {
        //La nave seguirá el cursor.
        Cursor.lockState = CursorLockMode.Locked;
        //Vectores para el disparo.
        d_Impulso = Vector3.forward * d_Fuerza;
        p_Explotion.Stop();
    }

    void Awake()
    {
        d_Stack = GetComponent<Disparo>();
    }

    // Update is called once per frame
    void Update()
    {
        //La nave se mueve a una velcidad continua.
        transform.position += transform.forward * p_Speed * Time.deltaTime;
        //Rotación de la nave.
        p_turn.x += Input.GetAxis("Mouse X") * p_Sensitivity;
        p_turn.y += Input.GetAxis("Mouse Y") * p_Sensitivity;
        transform.localRotation = Quaternion.Euler(-p_turn.y, p_turn.x, 0);
        //Valeores de los ejes.
        float vertical = Input.GetAxis("Vertical");

        //Determino en qué ejes puede acelerar la nave.
        p_Movement.Set(0f, 0f, vertical);

        //Aceleración y frenado + Fuerza de la bala.
        if (Input.GetKey(KeyCode.W))
        {
            p_Speed += p_Aceleration * Time.deltaTime;
            d_Fuerza += d_AceleracionFuerza * Time.deltaTime;

            if (p_Speed >= p_MaxSpeed)
            {
                p_Speed = p_MaxSpeed;
                d_Fuerza = d_MaxFuerza;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p_Speed -= p_Aceleration * Time.deltaTime;
            d_Fuerza -= d_AceleracionFuerza * Time.deltaTime;

            if (p_Speed <= p_MinSpeed)
            {
                p_Speed = p_MinSpeed;
                d_Fuerza = d_MinFuerza;
            }
        }

        //Input de disparo del jugador.
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bala = d_Stack.ObtenerObjeto();
            bala.transform.position = transform.position;
            bala.GetComponent<Rigidbody>().velocity = transform.forward * d_Fuerza;
            bala.GetComponent<Rigidbody>().AddForce(d_Impulso * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            p_Explotion.transform.position = transform.position;
            p_Explotion.Play();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            p_Explotion.transform.position = transform.position;
            p_Explotion.Play();
            Destroy(this.gameObject);
        }
    }

}
