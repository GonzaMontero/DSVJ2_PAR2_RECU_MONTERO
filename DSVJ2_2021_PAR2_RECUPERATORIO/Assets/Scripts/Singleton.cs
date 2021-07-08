using UnityEngine;

public class Singleton<C> : MonoBehaviour where C : Component
{
    public static C instance;

    public static C GetC()
    {
        return instance;
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as C;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
