using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp = 100;

    public int armor = 0;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    private bool isDead = false;

    private void Awake() {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start() 
    {
        hpBar.SetState(currentHp, maxHp);
    }

    private void Update() {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f) {
            Heal(1);
            hpRegenerationTimer--;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) { return; }
        
        ApplyArmor(ref damage);

        currentHp -= damage;
        if (currentHp <= 0) {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        
        hpBar.SetState(currentHp, maxHp);
    }

    public void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) {
            return;
        }

        currentHp += amount;

        if (currentHp > maxHp) {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
