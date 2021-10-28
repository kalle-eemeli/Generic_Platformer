using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projPrefab;
    public bool firingCd = false;
    private float cooldown = 2.0f;
    public Animator anim;
    public bool isTargetVisible;
    public GameObject player;
    public Quaternion defaultRotation;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnProjectiles();
        firingCd = true;
        StartCoroutine(FiringCooldown());
        anim = GetComponent<Animator>();
        anim.transform.position = transform.position;
        defaultRotation = Quaternion.identity;
        Debug.Log(defaultRotation.eulerAngles);
    }

    IEnumerator FiringCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        firingCd = false;
    }
    void SpawnProjectiles()
    {
        Vector3 pos = transform.position;
        pos.y += 0.2f;
        Instantiate(projPrefab, pos, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if(isTargetVisible == true)
        {
            if(firingCd == false)
            {
                anim.SetTrigger("Is_firing");
                SpawnProjectiles();
                firingCd = true;
                StartCoroutine(FiringCooldown());
            }
        }
        
    }
}
