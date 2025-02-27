using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }
public class GameEventListener : MonoBehaviour
{
    public Event gameEvent;  // Assign in Inspector
    public CustomGameEvent response;  // Drag and drop methods in Inspector

    private void OnEnable()
    {
        gameEvent.Register(OnEventRaised);
    }

    private void OnDisable()
    {
        gameEvent.Unregister(OnEventRaised);
    }

    private void OnEventRaised(Component sender, object data)
    {
        response?.Invoke(sender, data);
    }
}