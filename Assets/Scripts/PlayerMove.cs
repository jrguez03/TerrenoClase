using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] ParticleSystem p_Explosion;
    [SerializeField] GameObject p_Spawn;
    [SerializeField] AudioSource p_FlySource;
    [SerializeField] AudioSource p_ExplosionSource;

    public float p_Speed = 20f;
    public float p_Sensitivity = 1f;
    public float p_MinSpeed = 20f;
    public float p_MaxSpeed = 120f;
    public float p_Aceleration = 20f;
    public float p_PowerUpSpeed = 20f;
    public float p_PowerUpResetDuration = 5f;
    public float p_PowerUpDuration = 5f;
    public float p_SaveSpeed;

    bool p_PowerUp = false;

    Vector2 p_turn;
    Vector3 p_Movement;
    // Start is called before the first frame update
    void Start()
    {
        //La nave seguirá el cursor.
        Cursor.lockState = CursorLockMode.Locked;

        p_Explosion.Stop();

        p_FlySource.Play();
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

        //Aceleración y frenado.
        if (Input.GetKey(KeyCode.W))
        {
            p_Speed += p_Aceleration * Time.deltaTime;

            if (p_Speed >= p_MaxSpeed)
            {
                p_Speed = p_MaxSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p_Speed -= p_Aceleration * Time.deltaTime;

            if (p_Speed <= p_MinSpeed)
            {
                p_Speed = p_MinSpeed;
            }
        }

        //Aceleración de Power-up
        if (p_PowerUp == true)
        {
            p_Speed += p_PowerUpSpeed * Time.deltaTime;

            if(p_Speed >= p_MaxSpeed + p_PowerUpSpeed)
            {
                p_PowerUpDuration -= 1f * Time.deltaTime;
                p_Speed = p_MaxSpeed + p_PowerUpSpeed;

                if(p_PowerUpDuration <= 0f)
                {
                    p_PowerUp = false;
                }
            }
        }
        else if(p_PowerUpDuration <= 0f)
        {
            p_Speed -= p_PowerUpSpeed * Time.deltaTime;

            if (p_Speed <= p_SaveSpeed)
            {
                p_Speed = p_SaveSpeed;
                p_PowerUpDuration = 5f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            p_Explosion.transform.position = transform.position;
            p_Explosion.Play();
            p_ExplosionSource.Play();
            this.gameObject.SetActive(false);
            Invoke("ResetPlayer", 2f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            p_Explosion.transform.position = transform.position;
            p_Explosion.Play();
            p_ExplosionSource.Play();
            this.gameObject.SetActive(false);
            Invoke("ResetPlayer", 2f);
        }
    }

    void ResetPlayer()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = p_Spawn.transform.position;
        p_Speed = p_MinSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power-up"))
        {
            p_PowerUp = true;
            p_SaveSpeed = p_Speed;
        }
    }
}
