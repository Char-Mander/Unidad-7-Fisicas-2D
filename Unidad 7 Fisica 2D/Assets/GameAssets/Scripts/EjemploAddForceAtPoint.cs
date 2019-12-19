using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploAddForceAtPoint : MonoBehaviour
{
    public float moveForce;
    public GameObject eyePref;

    Rigidbody2D rigi;

    private ContactPoint2D[] contacts = new ContactPoint2D[10];

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigi.AddForce(Vector2.right * moveForce * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        rigi.AddForceAtPosition(transform.right * moveForce * Input.GetAxisRaw("Horizontal") * Time.deltaTime, transform.position);

        if (Input.GetKeyDown(KeyCode.O)) {
            int numeContacts = rigi.GetContacts(contacts);
            for (int i =0; i< numeContacts; i++) {
                ContactPoint2D contact = contacts[i];
                Instantiate(eyePref, contact.point, Quaternion.identity);
            }
        }

    }

}
