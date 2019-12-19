using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    PointEffector2D pointE;
    Animator anim;
    Rigidbody2D rigi;

    // Start is called before the first frame update
    void Start()
    {
        pointE = GetComponent<PointEffector2D>();
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();

        StartCoroutine(countDown());
    }

   
    void Explo() {
        rigi.isKinematic = true;
        anim.SetTrigger("Explo");
        StartCoroutine(EfdectImplosion());
    }

    IEnumerator EfdectImplosion() {
        pointE.forceMagnitude = -100;
        yield return new WaitForSeconds(1f);
        pointE.forceMagnitude = 100;
        Destroy(this.gameObject);
    }

    IEnumerator countDown() {
        yield return new WaitForSeconds(3);
        Explo();
    }

}
