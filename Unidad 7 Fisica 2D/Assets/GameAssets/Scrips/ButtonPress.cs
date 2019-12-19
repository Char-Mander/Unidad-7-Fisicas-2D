using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject bomb;
    public Transform posiSpawn;

    bool canPress = true;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            canPress = false;
            Instantiate(bomb, posiSpawn.position, posiSpawn.rotation);

        }
    }
}
