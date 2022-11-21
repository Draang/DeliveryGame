using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float volante = 0.5f;
    [SerializeField] float acelerador = 0.5f;
    /*  [SerializeField] float slowSpeed = 20;
     [SerializeField] float boostSpeed = 30; */

    // Update is called once per frame
    void Update()
    {
        float volanteDis = Input.GetAxis("Horizontal") * volante * Time.deltaTime;
        float aceleradorDis = Input.GetAxis("Vertical") * acelerador * Time.deltaTime;
        transform.Rotate(0, 0, -volanteDis);
        transform.Translate(0, aceleradorDis, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            acelerador = acelerador * 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (acelerador < 7)
        {
            acelerador = 7;
        }
        else
        {
            acelerador = acelerador/2;
        }
    }
}
