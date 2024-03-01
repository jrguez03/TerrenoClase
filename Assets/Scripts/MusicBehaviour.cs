using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource m_MusicSource;
    // Start is called before the first frame update
    void Start()
    {
        m_MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
