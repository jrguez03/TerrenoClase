using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] int d_MaxElements = 5;
    [SerializeField] GameObject d_ACrear;
    [SerializeField] GameObject d2_ACrear;
    [SerializeField] GameObject d3_ACrear;
    [SerializeField] GameObject d4_ACrear;

    private Stack<GameObject> d_Stack;
    private Stack<GameObject> d_Stack2;
    public static Disparo instance;
    public static Disparo instance2;
    public static Disparo instance3;
    public static Disparo instance4;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        d_Stack = new Stack<GameObject>();
        d_Stack2 = new Stack<GameObject>();
        GameObject disparoCreado = null;
        GameObject disparoCreado2 = null;
        GameObject disparoCreado3 = null;
        GameObject disparoCruado4 = null;

        for (int i = 0; i < d_MaxElements; i++)
        {
            disparoCreado = Instantiate(d_ACrear);
            disparoCreado2 = Instantiate(d2_ACrear);
            disparoCreado3 = Instantiate(d3_ACrear);
            disparoCruado4 = Instantiate(d4_ACrear);
            disparoCreado.SetActive(false);
            disparoCreado2.SetActive(false);
            disparoCreado3.SetActive(false);
            disparoCruado4.SetActive(false);
            d_Stack.Push(disparoCreado);
            d_Stack.Push(disparoCreado2);
            d_Stack2.Push(disparoCreado3);
            d_Stack2.Push(disparoCruado4);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject bala = null;
        GameObject bala2 = null;
        if (d_Stack.Count == 0)
        {
            GameObject disparoCreado = Instantiate(d_ACrear);
            GameObject disparoCreado2 = Instantiate(d2_ACrear);
            return disparoCreado;
            return disparoCreado2;
        }
        else
        {
            bala = d_Stack.Pop();
            bala2 = d_Stack.Pop();
            bala.SetActive(true);
            bala2.SetActive(true);
        }

        return bala;
        return bala2;
    }

    public GameObject ObtenerObjeto2()
    {
        GameObject bala3 = null;
        GameObject bala4 = null;
        if (d_Stack.Count == 0)
        {
            GameObject disparoCreado3 = Instantiate(d3_ACrear);
            GameObject disparoCreado4 = Instantiate(d4_ACrear);
            return disparoCreado3;
            return disparoCreado4;
        }
        else
        {
            bala3 = d_Stack2.Pop();
            bala4 = d_Stack2.Pop();
            bala3.SetActive(true);
            bala4.SetActive(true);
        }

        return bala3;
        return bala4;
    }

    public void DevolverObjeto(GameObject balaDevuelta)
    {
        d_Stack.Push(balaDevuelta);
        balaDevuelta.SetActive(false);
    }

    public void DevolverObjeto2(GameObject balaDevuelta2)
    {
        d_Stack.Push(balaDevuelta2);
        balaDevuelta2.SetActive(false);
    }

    public void DevolverObjeto3(GameObject balaDevuelta3)
    {
        d_Stack2.Push(balaDevuelta3);
        balaDevuelta3.SetActive(false);
    }

    public void DevolverObjeto4(GameObject balaDevuelta4)
    {
        d_Stack.Push(balaDevuelta4);
        balaDevuelta4.SetActive(false);
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
        if (instance2 == null)
        {
            instance2 = this;
        }
        else
        {
            Destroy(this);
        }
        if (instance3 == null)
        {
            instance3 = this;
        }
        else
        {
            Destroy(this);
        }
        if (instance4 == null)
        {
            instance4 = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
