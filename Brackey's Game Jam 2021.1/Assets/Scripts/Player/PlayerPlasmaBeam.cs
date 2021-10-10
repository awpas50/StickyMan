using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlasmaBeam : MonoBehaviour
{
    public GameObject firePoint;
    GameObject drone1;
    GameObject drone2;

    // generate colliders.
    public GameObject beamHitPoint;

    private bool isShooting = false;
    void Start()
    {
        drone1 = firePoint.transform.GetChild(0).gameObject;
        drone2 = firePoint.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isShooting = true;
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if(isShooting)
        {
            ShootBeam();
        }
        else if(!isShooting)
        {
            BeamCeaseFire();
        }
    }

    void ShootBeam()
    {
        beamHitPoint.SetActive(true);

        drone1.GetComponent<LineRenderer>().enabled = true;
        drone2.GetComponent<LineRenderer>().enabled = true;

        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0);
        Vector3 shootDir1 = (new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0) + new Vector3(-0.05f, 0.05f, 0) - drone1.transform.position).normalized;
        Vector3 shootDir2 = (new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0) + new Vector3(0.05f, -0.05f, 0) - drone2.transform.position).normalized;

        drone1.GetComponent<LineRenderer>().SetPosition(0, drone1.transform.position);
        RaycastHit hit1;
        if (Physics.Raycast(transform.position, shootDir1, out hit1))
        {
            if (hit1.collider.gameObject.tag != "Player")
            {
                drone1.GetComponent<LineRenderer>().SetPosition(1, hit1.point);
            }
        }
        else
        {
            drone1.GetComponent<LineRenderer>().SetPosition(1, shootDir1 * Vector3.Distance(drone1.transform.position, mousePos));
        }

        drone2.GetComponent<LineRenderer>().SetPosition(0, drone2.transform.position);
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, shootDir2, out hit2))
        {
            if (hit2.collider.gameObject.tag != "Player")
            {
                drone2.GetComponent<LineRenderer>().SetPosition(1, hit2.point);
            }
        }
        else
        {
            drone2.GetComponent<LineRenderer>().SetPosition(1, shootDir2 * Vector3.Distance(drone1.transform.position, mousePos));
        }
        //if (Vector3.Distance(gameObject.transform.position, beamHitPoint.transform.position) > 10)
        //{
        //    Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
        //        0);
        //    float lerpVariable = 10 / Vector3.Distance(drone1.transform.position, beamHitPoint.transform.position);

        //    //Debug.Log(Vector3.Distance(gameObject.transform.position, beamHitPoint.transform.position));
        //    Debug.Log(lerpVariable);

        //    Vector3 drone1MaxDistPoint = Vector3.Lerp(drone1.transform.position,
        //        mousePos + new Vector3(-0.05f, 0.05f, 0), lerpVariable);
        //    Vector3 drone2MaxDistPoint = Vector3.Lerp(drone2.transform.position,
        //        mousePos + new Vector3(0.05f, -0.05f, 0), lerpVariable);
        //    drone1.GetComponent<LineRenderer>().SetPosition(0, drone1.transform.position);
        //    drone1.GetComponent<LineRenderer>().SetPosition(1, drone1MaxDistPoint);
        //    drone2.GetComponent<LineRenderer>().SetPosition(0, drone2.transform.position);
        //    drone2.GetComponent<LineRenderer>().SetPosition(1, drone2MaxDistPoint);

        //    Vector3 maxDistPoint = Vector3.Lerp(gameObject.transform.position,
        //        mousePos, lerpVariable);
        //    beamHitPoint.transform.position = maxDistPoint;
        //}
        //if (Vector3.Distance(gameObject.transform.position, beamHitPoint.transform.position) <= 10)
        //{
        //    drone1.GetComponent<LineRenderer>().SetPosition(0, drone1.transform.position);
        //    drone1.GetComponent<LineRenderer>().SetPosition(1, 
        //        new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
        //        0) + new Vector3(-0.05f, 0.05f, 0));
        //    drone2.GetComponent<LineRenderer>().SetPosition(0, drone2.transform.position);
        //    drone2.GetComponent<LineRenderer>().SetPosition(1, 
        //        new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
        //        0) + new Vector3(0.05f, -0.05f, 0));

        //    beamHitPoint.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
        //        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 
        //        0);
        //}

    }
    void BeamCeaseFire()
    {
        beamHitPoint.SetActive(false);
        drone1.GetComponent<LineRenderer>().enabled = false;
        drone2.GetComponent<LineRenderer>().enabled = false;
    }
}
