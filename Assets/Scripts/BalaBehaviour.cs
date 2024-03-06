using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    float b_Time = 0.0f;
    [SerializeField] float b_LifeTime = 2f;
    [SerializeField] AudioSource b_HitSource;

    // Update is called once per frame
    void Update()
    {
        b_Time += Time.deltaTime;
        if (b_Time > b_LifeTime)
        {
            this.gameObject.SetActive(false);
            Disparo.instance.DevolverObjeto(this.gameObject);
        }
    }

    void OnEnable()
    {
        b_Time = 0.0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terreno"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            b_HitSource.Play();
            this.gameObject.SetActive(false);
        }
    }
}
