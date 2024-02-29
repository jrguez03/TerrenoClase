using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem e_Explosion;
    [SerializeField] AudioSource e_ExplosionSource;

    public float e_Vida = 4;

    // Start is called before the first frame update
    void Start()
    {
        e_Explosion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala player"))
        { 
            e_Vida = e_Vida - 1;
            if (e_Vida <= 0)
            {
                e_Explosion.transform.position = transform.position;
                e_Explosion.Play();
                e_ExplosionSource.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
