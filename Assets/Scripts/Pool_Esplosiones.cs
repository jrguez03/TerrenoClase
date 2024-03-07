using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Esplosiones : MonoBehaviour
{
    [SerializeField] int ex_MaxElements = 5;
    [SerializeField] GameObject ex_ACrear;

    private Stack<GameObject> ex_Stack;
    public static Pool_Esplosiones instance;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        ex_Stack = new Stack<GameObject>();
        GameObject explosionCreada = null;

        for (int i = 0; i < ex_MaxElements; i++)
        {
            explosionCreada = Instantiate(ex_ACrear);
            explosionCreada.SetActive(false);
            ex_Stack.Push(explosionCreada);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject explosion = null;

        if (ex_Stack.Count == 0)
        {
            GameObject explosionCreada = Instantiate(ex_ACrear);
            ex_Stack.Push(explosionCreada);
            return explosionCreada;
        }
        else
        {
            explosion = ex_Stack.Pop();
            explosion.SetActive(true);
        }

        return explosion;
    }

    public void DevolverObjeto(GameObject explosionDevuelta)
    {
        ex_Stack.Push(explosionDevuelta);
        explosionDevuelta.SetActive(false);
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
