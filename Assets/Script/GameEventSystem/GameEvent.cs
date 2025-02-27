using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event")]
public class Event : ScriptableObject
{
    private event Action<Component, object> _listeners;


    public void Raise(Component sender, object data)
    {
        _listeners?.Invoke(sender, data);
    }

    public void Register(Action<Component, object> listener)
    {
        _listeners += listener;
    }

    public void Unregister(Action<Component, object> listener)
    {
        _listeners -= listener;
    }
}
