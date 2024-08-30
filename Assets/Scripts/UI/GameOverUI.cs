using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public void Setup(int tokenCount)
    {
        gameObject.SetActive(true);
        textMesh.text = tokenCount.ToString() + " Gems Collected";
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); 
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0); 
    }

}
