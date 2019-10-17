using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    static private bool cbMode;

    public void Start ()
    {
        colorblindMode.isOn = cbMode;
    }
    public void PlayMaze()
    {
        cbMode = colorblindMode.isOn;
        if (cbMode)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
