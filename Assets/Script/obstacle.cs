using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 0, 180 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        BotMovement bot = other.GetComponent<BotMovement>();
        if (other.tag == "Player")
        {
            player.chamchuongngaivat(0);
        }
        if (other.tag == "bot")
        {
            bot.chamchuongngaivat(0);
        }
    }
}
