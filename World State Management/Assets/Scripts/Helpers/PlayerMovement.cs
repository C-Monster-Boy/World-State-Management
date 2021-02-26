/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    public void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xDelta = xInput * moveSpeed * Time.deltaTime;
        float zDelta = yInput * moveSpeed * Time.deltaTime;

        Vector3 moveDelta = new Vector3(xDelta, 0, zDelta);

        transform.position += moveDelta;

    }
}
