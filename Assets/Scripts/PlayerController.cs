using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    private int health = 5;
    private int score = 0;
    public Rigidbody body;
    public float speed = 750;
    public Text scoreText;
    public Text healthText;
    public Text winLoseT;
    public Image winLoseB;

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
            winLoseB.color = Color.green;
            winLoseT.color = Color.black;
            winLoseT.text = "You Win!";
            winLoseB.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            //Debug.Log ("You win!");
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            winLoseT.text = "Game Over!";
            winLoseB.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            //Debug.Log ("Game Over!");
            //SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        }
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
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
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        score = 0;
        health = 5;
    }
}
