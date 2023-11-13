using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InputHandler : MonoBehaviour
{
    public GameObject introCanvas;
    public GameObject player;
    public CanvasGroup fadePanel; // Reference to your canvas group with the black panel

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
        StartCoroutine(FadeAndLoad(sceneIndex));
    }

    private IEnumerator FadeAndLoad(int sceneIndex)
    {
        // Fade out
        while (fadePanel.alpha < 1)
        {
            fadePanel.alpha += Time.deltaTime;
            yield return null;
        }

        // Load scene
        SceneManager.LoadScene(sceneIndex);

        // Fade in
        while (fadePanel.alpha > 0)
        {
            fadePanel.alpha -= Time.deltaTime;
            yield return null;
        }
    }

    public void Exit()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
    UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
  }
}