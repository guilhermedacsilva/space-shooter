using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;
        rb.AddForce(movement * speed);

        rb.transform.position = new Vector3(
            Mathf.Clamp(rb.transform.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.transform.position.z, boundary.zMin, boundary.zMax)
        );

        Debug.Log(rb.transform.position);
    }
}
