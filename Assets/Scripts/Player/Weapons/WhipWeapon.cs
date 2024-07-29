using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;

    PlayerController playerMove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
    
    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerController>();
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++) {
            IDamageable e = colliders[i].GetComponent<IDamageable>();

            if (e != null) {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack() 
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) {
            if (playerMove.lastHorizontalInput > 0f) {
            rightWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
            ApplyDamage(colliders);

            } else {
                leftWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
