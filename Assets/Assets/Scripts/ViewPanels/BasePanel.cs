using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    private bool _activateCalled = false;
    public void Activate() 
    {
        ServiceManager.ViewManager.CurrentActivePanel?.Deactivate();
        gameObject.SetActive(true);
        ServiceManager.ViewManager.CurrentActivePanel = this;
        OnActivate();
        _activateCalled = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        if(ServiceManager.ViewManager.CurrentActivePanel == this) 
        {
            ServiceManager.ViewManager.CurrentActivePanel = null;
        }
        if(_activateCalled) // Ensure deactivate only called after activate
        {
            _activateCalled = false;
            OnDeactivate();
        }
    }

    virtual protected void OnActivate(){}
    virtual protected void OnDeactivate(){}

    virtual protected void OnBack(){}
}
