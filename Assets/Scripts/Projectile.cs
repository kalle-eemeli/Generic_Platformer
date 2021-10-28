using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem destructionParticle;
    public float speed = 60.0f;
    private Rigidbody projRb;
    //private float timetolive = 3.0f;
    private bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        projRb = GetComponent<Rigidbody>();
        //projRb.AddForce(Vector3.forward * -speed, ForceMode.Impulse);
        StartCoroutine(SetToDestroy(5.0f));
    }

    IEnumerator SetToDestroy(float a)
    {
        yield return new WaitForSeconds(a);
        kill = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        if(kill == true)
        {
            Destroy(gameObject);
            Instantiate(destructionParticle, transform.position, destructionParticle.transform.rotation);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Instantiate(destructionParticle, transform.position, destructionParticle.transform.rotation);
    }
}
