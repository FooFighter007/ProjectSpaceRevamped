using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameHasEnded = false;
    public ParticleSystem Burner;
    public Mesh myMesh;

    public void Start()
    {
        if(PlayerPrefs.GetInt("MaxLevel") < 1)
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
        Debug.Log("Play");
    }


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Burner.emissionRate = 1000f;
            var sh = Burner.shape;
            sh.enabled = true;
            sh.shapeType = ParticleSystemShapeType.Mesh;
            sh.mesh = myMesh;
            
            Invoke("Restart", 3f);
        }
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


    public void ResetGame()
    {
        PlayerPrefs.SetInt("MaxLevel", 1);
        SceneManager.LoadScene(0);
    }


    public void LevelComplete()
    {
        if (PlayerPrefs.GetInt("MaxLevel") < SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
