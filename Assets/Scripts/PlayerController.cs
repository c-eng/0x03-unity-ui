using UnityEngine;

///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 750;
    private int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            body.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            body.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            body.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            body.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log ("Score: " + score);
            Destroy(other.gameObject);
        }
    }
}
