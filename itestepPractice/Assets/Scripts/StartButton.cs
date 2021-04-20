using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetScore()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
