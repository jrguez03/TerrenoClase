using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] int d_MaxElements = 5;
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

    public GameObject ObtenerObjeto()
    {
        GameObject bala = null;
        if (d_Stack.Count == 0)
        {
            GameObject disparoCreado = Instantiate(d_ACrear);
            return disparoCreado;
        }
        else
        {
            bala = d_Stack.Pop();
            bala.SetActive(true);
        }

        return bala;
    }

    public void DevolverObjeto(GameObject balaDevuelta)
    {
        d_Stack.Push(balaDevuelta);
        balaDevuelta.SetActive(false);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
