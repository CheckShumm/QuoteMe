using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
    protected void Awake() 
    {
        RegisterManager();
    }

    protected abstract void RegisterManager();
}
