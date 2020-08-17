using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MBSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // check to see if we're about to be destroyed
    private static bool _shuttingDown = false;
    private static object _lock = new object();

    private static T _instance;
    // access singleton instance through this property
    // Lazy Instantiation!
    public static T Instance
    {
        get
        {
            // if we're already shutting down, return null
            if (_shuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) 
                    + "'already destroyed. Returning null.");
                return null;
            }
            // ensure only one instance completes the code block, so we can assign the first instance safely
            lock(_lock)
            {
                if(_instance == null)
                {
                    // search for existing instance.
                    _instance = (T)FindObjectOfType(typeof(T));
                    // create new instance if one doesn't already exist
                    if (_instance == null)
                    {
                        // need to create a new GameObject to attach Singleton component to
                        GameObject singletonGameObject = new GameObject();
                        _instance = singletonGameObject.AddComponent<T>();
                        singletonGameObject.name = typeof(T).ToString() + " (Singleton)";
                        // make instance persistent
                        DontDestroyOnLoad(singletonGameObject);
                        // get notifications when we load a new level
                    }
                }

                return _instance;
            }
        }
    }
    
    private void OnApplicationQuit()
    {
        _shuttingDown = true;
    }

    private void OnDestroy()
    {
        _shuttingDown = true;
    }
}
