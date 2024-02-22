using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] int d_MaxElements = 50;
    [SerializeField] GameObject d_ACrear;

    private Stack<GameObject> d_Stack;
    public static Disparo instance;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        d_Stack = new Stack<GameObject>();
        GameObject disparoCreado = null;

        for (int i = 0; i < d_MaxElements; i++)
        {
            disparoCreado = Instantiate(d_ACrear);
            disparoCreado.SetActive(false);
            d_Stack.Push(disparoCreado);
        }
    }

    /*public GameObject ObtenerObjeto()
    {
        GameObject bala = null;
    }*/
}
