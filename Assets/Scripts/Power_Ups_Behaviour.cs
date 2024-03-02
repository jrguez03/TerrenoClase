using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Ups_Behaviour : MonoBehaviour
{
    [SerializeField] GameObject pw_LimitSpawn1;
    [SerializeField] GameObject pw_LimitSpawn2;
    [SerializeField] GameObject pw_Boost;
    [SerializeField] GameObject pw_Vortex;

    public float pw_RotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //Se obtiene la rotacion actual.
        Quaternion pw_CurrentRotation = transform.rotation;

        //Calcula la rotacion deseada en el eje indicado.
        Quaternion pw_DesiredRotation = Quaternion.Euler(0f, pw_RotationSpeed * Time.deltaTime, 0f);

        //Aplicamos la rotación.
        transform.rotation = pw_CurrentRotation * pw_DesiredRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pw_Boost.SetActive(false);
            pw_Vortex.SetActive(false);

            float randomX = Random.Range(pw_LimitSpawn1.transform.position.x, pw_LimitSpawn2.transform.position.x);
            float randomY = Random.Range(pw_LimitSpawn1.transform.position.y, pw_LimitSpawn2.transform.position.y);
            float randomZ = Random.Range(pw_LimitSpawn1.transform.position.z, pw_LimitSpawn2.transform.position.z);

            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
            transform.position = randomPosition;

            pw_Boost.SetActive(true);
            pw_Vortex.SetActive(true);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pw_LimitSpawn1 != null && pw_LimitSpawn2 != null)
        {
            Vector3 centro = (pw_LimitSpawn1.transform.position + pw_LimitSpawn2.transform.position) * 0.5f;
            Vector3 tamaño = new Vector3 (Mathf.Abs(pw_LimitSpawn1.transform.position.x - pw_LimitSpawn2.transform.position.x), Mathf.Abs(pw_LimitSpawn1.transform.position.y - pw_LimitSpawn2.transform.position.y), Mathf.Abs(pw_LimitSpawn1.transform.position.z - pw_LimitSpawn2.transform.position.z));

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(centro, tamaño);
        }
    }
}
