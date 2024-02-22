using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float p_Speed = 20f;
    public float p_Sensitivity = 1f;
    public float p_MinSpeed = 20f;
    public float p_MaxSpeed = 120f;
    public float p_Aceleration = 10f;

    Vector2 p_turn;
    Vector3 p_Movement;
    // Start is called before the first frame update
    void Start()
    {
        //La nave seguir� el cursor.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //La nave se mueve a una velcidad continua.
        transform.position += transform.forward * p_Speed * Time.deltaTime;
        //Rotaci�n de la nave.
        p_turn.x += Input.GetAxis("Mouse X") * p_Sensitivity;
        p_turn.y += Input.GetAxis("Mouse Y") * p_Sensitivity;
        transform.localRotation = Quaternion.Euler(-p_turn.y, p_turn.x, 0);
        //Valeores de los ejes.
        float vertical = Input.GetAxis("Vertical");

        //Determino en qu� ejes puede acelerar la nave.
        p_Movement.Set(0f, 0f, vertical);

        //Aceleraci�n y frenado.
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
    }
}