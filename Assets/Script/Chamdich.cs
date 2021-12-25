using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chamdich : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (other.tag == "bot")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
