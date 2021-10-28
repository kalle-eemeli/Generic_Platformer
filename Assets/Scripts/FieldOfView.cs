using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    // Start is called before the first frame update
    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    RaycastHit hit;
    public float rotationSpeed = 100.0f;
    //public Vector3 offset = new Vector3(0,1,0);
    //public bool turret;
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position,viewRadius,targetMask);
        Transform turret2 = this.gameObject.transform.GetChild(0);
        Quaternion defRot = this.gameObject.GetComponentInChildren<Turret>().defaultRotation;

        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward,dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    //turret2.rotation = Quaternion.Lerp(turret2.rotation, Quaternion.LookRotation(dirToTarget), Time.deltaTime * rotationSpeed);
                    //turret2.LookAt(target.position);
                    RotateTurret(turret2, turret2.rotation, dirToTarget);
                }

            }
            
        }

        if(visibleTargets.Count == 0)
        {
            this.gameObject.GetComponentInChildren<Turret>().isTargetVisible = false;
            //turret2.rotation = Quaternion.RotateTowards(turret2.rotation,defRot,Time.deltaTime * 10.0f);
        }

    }

    IEnumerator CDClear()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponentInChildren<Turret>().isTargetVisible = true;
    }
    void RotateTurret(Transform transform,Quaternion rotation, Vector3 vector3)
    {
        transform.rotation = Quaternion.Lerp(rotation, Quaternion.LookRotation(vector3), Time.deltaTime * rotationSpeed);
        StartCoroutine(CDClear());
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    void Start()
    {
        //turret = this.gameObject.GetComponentInChildren<Turret>().isTargetVisible;
        //StartCoroutine(FindTargetsWithDelay(3f));
    }

    // Update is called once per frame
    void Update()
    {
        FindVisibleTargets();
    }   
}
