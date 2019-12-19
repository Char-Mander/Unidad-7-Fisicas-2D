using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAbility : MonoBehaviour
{
    public float stopDist = 1;

    SpringJoint2D spJoint;
    Rigidbody2D otherRigi;

    bool canSaltoS = false;

    // Start is called before the first frame update
    void Start()
    {
        spJoint = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E) && otherRigi != null)
        {
            if (canSaltoS)
            {
                spJoint.enabled = true;
                canSaltoS = false;
                spJoint.connectedBody = otherRigi;
            }else {
                spJoint.enabled = false;
                otherRigi = null;
            }
            

        }

       /* if (spJoint.isActiveAndEnabled == true && otherRigi != null)
        {
            float distToObject = Vector2.Distance(this.transform.position, otherRigi.gameObject.transform.position);
           
            if (distToObject < stopDist)
            {
                spJoint.enabled = false;
                otherRigi = null;
            }
        }
*/

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            canSaltoS = true;
            otherRigi = col.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player") {
            canSaltoS = false;
        }
    }
}
