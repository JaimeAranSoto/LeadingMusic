using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;
    public bool isPersistant;

    public virtual void Awake()
    {
        if (isPersistant)
        {
            if (!Instance)
            {
                Instance = this as T;
            }
            else
            {
                DestroyObject(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this as T;
        }
    }
}