using System;
using UnityEngine;


public abstract class AbstractLazySingleton<T> : MonoBehaviour where T : MonoBehaviour

{
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null) instance = (T) GameObject.FindObjectOfType(typeof(T));
            if (instance == null) instance = new GameObject(nameof(T)).AddComponent<T>();

            return instance;
        }
    }
}