using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIController uIReference;
    //Array con todos los tipos de Slimes
    public GameObject[] slimes;

    //Método para cuando llegamos al GameOver
    public void GameOver()
    {
        //Activamos el texto de GameOver
        uIReference.gameOverText.gameObject.SetActive(true);

        Invoke("ChangeScene", 1.5f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
