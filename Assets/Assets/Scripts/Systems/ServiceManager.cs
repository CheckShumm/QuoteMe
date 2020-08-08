using UnityEngine;

public static class ServiceManager
{
    public static AppManager AppManager { get {return _appManager.Value;} set { _appManager.Value = value; } }
    public static ViewManager ViewManager { get {return _viewManager.Value;} set { _viewManager.Value = value; } }


    // Singleton protection
    private static readonly WriteOnce<AppManager> _appManager = new WriteOnce<AppManager>();
    private static readonly WriteOnce<ViewManager> _viewManager = new WriteOnce<ViewManager>();
}

public sealed class WriteOnce<T> 
{
    private T _value;
    private bool _hasValue;
    public T Value {
        get { return _value; }
        set 
        {
            Debug.Assert(!_hasValue, "Trying to set a Singleton more than once!");
            _value = value;
            _hasValue = true;
        }
    } 
}
