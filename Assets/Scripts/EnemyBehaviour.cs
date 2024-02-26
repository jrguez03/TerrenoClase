using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem e_Explotion;

    // Start is called before the first frame update
    void Start()
    {
        e_Explotion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala player"))
        { 
            e_Explotion.transform.position = transform.position;
            e_Explotion.Play();
            Destroy(this.gameObject);
        }
    }
}
