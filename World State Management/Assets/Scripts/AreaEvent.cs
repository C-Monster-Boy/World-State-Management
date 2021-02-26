/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AreaEvent
{
    public string eventName;
    public string areaToEffect;
    public AreaStates newAreaState;
    public UnityEvent eventsToTrigger;
}
