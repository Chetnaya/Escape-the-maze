using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardTriggerHandler : MonoBehaviour
{
    public GameObject gameEndCanvas; // Assign the Level End Canvas in the Unity Editor

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skateboard"))
        {
            gameEndCanvas.SetActive(true);
        }
    }
}
