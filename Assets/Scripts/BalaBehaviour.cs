using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    float b_Time = 0.0f;
    [SerializeField] float b_LifeTime = 2f;

    // Update is called once per frame
    void Update()
    {
        b_Time += Time.deltaTime;
        if (b_Time > b_LifeTime)
        {
            this.gameObject.SetActive(false);
            Disparo.instance.DevolverObjeto(this.gameObject);
            Disparo.instance2.DevolverObjeto2(this.gameObject);
            Disparo.instance3.DevolverObjeto3(this.gameObject);
            Disparo.instance4.DevolverObjeto4(this.gameObject);
        }
    }

    void OnEnable()
    {
        b_Time = 0.0f;
    }
}
