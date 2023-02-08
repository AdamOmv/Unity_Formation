using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float saut = 0.24f;
    public float descente = 0.24f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sidewaysForce* Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("q") || Input.GetKey("left"))
        {
            rb.AddForce(-sidewaysForce* Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("space") && rb.position.y < 3f)
        {
            rb.AddForce(0, saut, 0, ForceMode.VelocityChange);
                
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if(rb.position.y > 3f)
        {
            rb.AddForce(0, -descente, 0, ForceMode.VelocityChange);
        }
    }
}
