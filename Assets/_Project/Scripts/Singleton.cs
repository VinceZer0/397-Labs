using UnityEditor.PackageManager;
using UnityEngine;

namespace Platformer397
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public bool AutoUnparentOnwake = true;
        protected static T instance;

        public static bool HasInstance => instance != null;

        public static T TryGetInstance() => HasInstance ? instance : null;
        
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindAnyObjectByType<T>();

                    if(instance == null)
                    {
                        var go = new GameObject(typeof(T).Name + "Generated");
                        instance = go.AddComponent<T>();
                    }    
                }
                return instance;
            }
        }

        protected virtual void Awake() 
        { 
            if(AutoUnparentOnwake)
            {
                transform.SetParent(null);
            }
            if(instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
