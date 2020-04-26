using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask mask;

    private LineRenderer lineRenderer;
    private BoxCollider2D BC2D;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;

        BC2D = GetComponent<BoxCollider2D>();
        BC2D.offset = Vector2.zero;
        BC2D.size = new Vector2(0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer.enabled)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 100, mask);
            float length = Vector3.Distance(transform.position, hit.point);
            BC2D.offset = new Vector2(0, -length / 2);
            BC2D.size = new Vector2(0.1f, length);

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            BC2D.offset = Vector2.zero;
            BC2D.size = new Vector2(0.1f, 0.1f);
        }
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    public void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
