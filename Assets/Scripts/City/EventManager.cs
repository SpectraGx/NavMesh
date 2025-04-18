using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<Vector3> OnExplosionEvent;

    public static void TriggerExplosion(Vector3 position)
    {
        OnExplosionEvent?.Invoke(position);
    }
}
