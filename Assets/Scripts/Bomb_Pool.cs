using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Pool : MonoBehaviour
{
    [SerializeField] int b_MaxElements = 10;
    [SerializeField] GameObject b_ACrear;

    private Stack<GameObject> b_Stack;
    public static Bomb_Pool instance;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        b_Stack = new Stack<GameObject>();
        GameObject disparoCreado = null;

        for (int i = 0; i < b_MaxElements; i++)
        {
            disparoCreado = Instantiate(b_ACrear);
            disparoCreado.SetActive(false);
            b_Stack.Push(disparoCreado);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject bomba = null;
        if (b_Stack.Count == 0)
        {
            GameObject disparoCreado = Instantiate(b_ACrear);
            b_Stack.Push(disparoCreado);
            return disparoCreado;
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
