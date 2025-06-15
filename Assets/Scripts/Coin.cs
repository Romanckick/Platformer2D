using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddCoin();
            Destroy(gameObject);
        }
    }
}