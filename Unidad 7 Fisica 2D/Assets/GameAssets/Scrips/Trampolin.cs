using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{

	public float force;
    public float reloadTime = 0.3f;

    RelativeJoint2D relativeJ;
    bool canJump = true;

    private void Start()
    {
        relativeJ = GetComponent<RelativeJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && canJump) {
            canJump = false;
            relativeJ.maxForce = force;
            StartCoroutine(Reaload());
        }
    }

    IEnumerator Reaload() {
        yield return new WaitForSeconds(reloadTime);
        relativeJ.maxForce = 2;
        canJump = true;
    }

}
