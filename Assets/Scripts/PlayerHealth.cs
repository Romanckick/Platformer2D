using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public TMP_Text livesText;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Викликається при зіткненні з колайдером ворога
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        livesText.text = currentHealth + " Lives";

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Гравець загинув!");
        // Тут додай логіку смерті гравця (перезапуск рівня, анімації і т.д.)
        // Наприклад:
        SceneManager.LoadScene("Menu");
    }
}
