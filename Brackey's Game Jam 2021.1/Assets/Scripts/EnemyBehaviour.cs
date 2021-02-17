using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject attackTarget;
    public Transform lastKnownPosition;
    public float range;


    private float t = 0;
    private float cd = 0.3f;
    void Start()
    {
        attackTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void UpdateTarget_Close()
    {
        if(t >= cd)
        {
            lastKnownPosition = attackTarget.transform;
            t = 0;
        }
    }

    void AimAtTarget()
    {
        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Quaternion.LookRoation: instance lock a new target
        //Quaternion.Lerp: lock a target (from A to B) with a speed
        //Therefore we use Quaternion.Lerp here.
        //Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretStat.turnSpeed).eulerAngles;
        //only rotate Y-axis
        //partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    
    void Update()
    {
        t += Time.deltaTime;
        UpdateTarget_Close();
        AimAtTarget();
    }
}
