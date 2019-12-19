using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisions : MonoBehaviour
{
    public float detectDist;
    public LayerMask lm;

    private void OnCollisionEnter2D(Collision2D col)
    {
        print("Entra en colisión 2D");
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        print("Se mantiene en colisión 2D");
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        print("Sale en colisión 2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Entra en trigger 2D");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Se mantiene en trigger 2D");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("sale en trigger 2D");
    }

    private void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, detectDist, lm);
        if (col != null) { 
            print(col.gameObject.name);
        }
       
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, lm) ;

       print(hit.collider.gameObject.name);
        Debug.DrawLine(transform.position, hit.point, Color.blue); 
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectDist);
    }

}
