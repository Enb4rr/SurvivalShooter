using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharacterStats
{
    [SerializeField] public Slider hpSlider;
    [SerializeField] public GameObject mainCanvas;
    [SerializeField] public GameObject gameOverCanvas;

    public Player(float healthPoints, float maxHealthPoints, bool isDead) : base(healthPoints, maxHealthPoints, isDead)
    {
    }

    public override void ReceiveDamage(float Damage)
    {
        base.ReceiveDamage(Damage);
        hpSlider.SetValueWithoutNotify((HealthPoints * 0.01f));
    }

    public override void HandleDeath()
    {
        base.HandleDeath();
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void HandleRestart()
    {
        base.HandleRestart();
    }
}
