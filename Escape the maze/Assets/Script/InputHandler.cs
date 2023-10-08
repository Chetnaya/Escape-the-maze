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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}