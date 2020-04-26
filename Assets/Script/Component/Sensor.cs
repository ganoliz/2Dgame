using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public List<GameObject> LaserObjs;
    private int count;

    private void Start()
    {

    }

    private void Update()
    {
        if (count == 0)
        {
            foreach(GameObject obj in LaserObjs)
            {
                obj.GetComponentInChildren<Laser>().EnableLaser();
            }
        }
        else
        {
            foreach (GameObject obj in LaserObjs)
            {
                obj.GetComponentInChildren<Laser>().DisableLaser();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Object" || collision.tag == "Player")
        {
            laser.DisableLaser();
        }
    }*/
}
