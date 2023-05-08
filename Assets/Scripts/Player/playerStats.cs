using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp = 100;

    public float hpRegenarate = 0.5f;
    public float hpRegenTimer;


    [SerializeField] statusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coin coin;

    private void Awake()
    {
        level = GetComponent<Level>();
        coin = GetComponent<Coin>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }

    private void Update()
    {
        hpRegenTimer += Time.deltaTime * hpRegenarate;

        if (hpRegenTimer > 1f)
        {
            Heal(1);
            hpRegenTimer -= 1f;
        }
    }

    private bool isDead;

    public void TakeDamage(int damage)
    {
        if (isDead == true) { return; }
        currentHp -= damage;

        if(currentHp <=0 )
        {
            GetComponent<playerGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
