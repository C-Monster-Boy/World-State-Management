/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Area State", menuName = "Area State")]
public class SO_AreaState : ScriptableObject
{
    public string areaName;
    public WorldStates[] id_acceptableWorldStateList;
    public AreaStates id_areaState;

    public GameObject prefabToLoad;
}
