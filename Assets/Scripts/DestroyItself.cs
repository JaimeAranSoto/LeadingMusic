using UnityEngine;
using System.Collections;

public class DestroyItself : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}