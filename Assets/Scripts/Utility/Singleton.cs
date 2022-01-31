using UnityEngine;

public static class Singleton
{
    public static T MakeInstance<T>(T _this, T instance) where T : Object
    {
        if (instance != null && instance != _this)
        {
            Debug.LogWarning(_this.name + " has been deleted");
            Object.Destroy(_this);
            if(_this is MonoBehaviour)  
                Object.Destroy((_this as MonoBehaviour).gameObject);
        }
        else
        {
            instance = _this;
        }
        return instance;
    }
}
