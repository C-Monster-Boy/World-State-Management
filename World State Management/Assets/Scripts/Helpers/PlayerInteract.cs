/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform raycastOrigin;
    public float raycastLength;

    private void Update()
    {
        RaycastHit ray;

        Vector3 direction = Vector3.Normalize(raycastOrigin.position - transform.position);
        if (Physics.Raycast(raycastOrigin.position, direction, out ray, raycastLength))
        {

            if(ray.collider.tag == "Interactable")
            {
                //Press E to interact
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ray.collider.GetComponent<SmilieKiller>())
                {
                    print("Found Smiles");
                    ray.collider.GetComponent<SmilieKiller>().KillTheSmilie_Interact();
                }
            }
               
                
           
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = Vector3.Normalize(raycastOrigin.position - transform.position);
        Gizmos.DrawWireSphere(raycastOrigin.position, raycastLength);
    }
}
