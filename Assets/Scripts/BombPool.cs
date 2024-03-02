using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    [SerializeField] int d_MaxElements = 5;
    [SerializeField] GameObject b_ACrear;

    private Stack<GameObject> b_Stack;
    public static BombPool instance;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        b_Stack = new Stack<GameObject>();
        GameObject bombaCreada = null;

        for (int i = 0; i < d_MaxElements; i++)
        {
            bombaCreada = Instantiate(b_ACrear);
            bombaCreada.SetActive(false);
            b_Stack.Push(bombaCreada);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject bomba = null;

        if (b_Stack.Count == 0)
        {
            GameObject bombaCreada = Instantiate(b_ACrear);
            b_Stack.Push(bombaCreada);
            return bombaCreada;
        }
        else
        {
            bomba = b_Stack.Pop();
            bomba.SetActive(true);
        }

        return bomba;
    }

    public void DevolverObjeto(GameObject bombaDevuelta)
    {
        b_Stack.Push(bombaDevuelta);
        bombaDevuelta.SetActive(false);
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
