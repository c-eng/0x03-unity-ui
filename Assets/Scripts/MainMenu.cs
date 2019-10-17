using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
