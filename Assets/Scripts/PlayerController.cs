using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 750;
    private int health = 5;
    private int score = 0;
    public Text scoreText;
    public Text healthText;

    void FixedUpdate()
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
            //Debug.Log ("Score: " + score);
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
            //Debug.Log ("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            Debug.Log ("You win!");
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log ("Game Over!");
            SceneManager.LoadScene("Maze", LoadSceneMode.Single);
            score = 0;
            health = 5;
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
