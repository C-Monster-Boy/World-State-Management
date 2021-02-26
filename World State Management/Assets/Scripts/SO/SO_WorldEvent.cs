/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New World Event", menuName = "World Event")]
public class SO_WorldEvent : ScriptableObject
{
    public string worldEventName;
    public WorldStates newWorldState;
    public AreaEventWithAreaName[] areaEventsToTrigger;
}

[System.Serializable]
public struct AreaEventWithAreaName
{
    public string areaName;
    public AreaStates newAreaState;
    public string areaEvent;
}
