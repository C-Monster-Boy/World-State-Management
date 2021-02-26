/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmilieKiller : MonoBehaviour
{
    public Material deadMaterial;
    public bool killWithInteract;
    public bool isAlive;

    public void KillTheSmilie_Interact()
    {
        if (killWithInteract)
        {
            KillTheSmilie();
            FindObjectOfType<AreaStateManager>().InvokeAreaEvent("Smilie death kills another");
        }       
    }

    public void KillTheSmilie_Event()
    {
        KillTheSmilie();
    }

    private void KillTheSmilie()
    {
        gameObject.GetComponent<MeshRenderer>().material = deadMaterial;
        killWithInteract = false;
        isAlive = false;
    }
}
