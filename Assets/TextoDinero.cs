using UnityEngine;
using System.Collections;

public class TextoDinero : Singleton<TextoDinero>
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void Animar()
    {
        anim.SetTrigger("Cambio");
    }
    void OnEnable()
    {
        if (anim != null)
            anim.Play("dinero");
    }
}