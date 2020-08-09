using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public void Activate() 
    {
        ServiceManager.ViewManager.CurrentActivePanel?.Deactivate();
        gameObject.SetActive(true);
        ServiceManager.ViewManager.CurrentActivePanel = this;
        OnActivate();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        if(ServiceManager.ViewManager.CurrentActivePanel == this) 
        {
            ServiceManager.ViewManager.CurrentActivePanel = null;
        }
    }

    virtual protected void OnActivate(){}

    virtual protected void OnBack(){}
}
