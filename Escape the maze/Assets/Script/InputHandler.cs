using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public GameObject introCanvas;
    public GameObject player;
    void Start()
    {
        introCanvas.SetActive(true);
        player.SetActive(false);
    }
    public void YesButton()
    {
        introCanvas.SetActive(false);
        player.SetActive(true);
    }
    public void playAgainButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class InputHandler : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
