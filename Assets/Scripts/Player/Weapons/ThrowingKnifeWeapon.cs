using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
    [SerializeField] GameObject knifePrefab;

    PlayerController playerMove;

    [SerializeField] float knifeSpeed = 5f;
    [SerializeField] float spread = 0.5f;

    private void Awake() {
        playerMove = GetComponentInParent<PlayerController>();
    }
    
    public override void Attack()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) {
            GameObject thrownKnife = Instantiate(knifePrefab);

            Vector3 newKnifePosition = transform.position;
            if (weaponStats.numberOfAttacks > 1) {
                newKnifePosition.y -= (spread * weaponStats.numberOfAttacks - 1) / 2; // calculating offset
                newKnifePosition.y += i * spread; // applying offset, spreading the knives along the line
            }

            thrownKnife.transform.position = newKnifePosition;

            ThrowingKnifeProjectile throwingKnifeProjectile = thrownKnife.GetComponent<ThrowingKnifeProjectile>();

            if (playerMove.lastHorizontalInput > 0) {
                throwingKnifeProjectile.SetDirection(knifeSpeed, 0f);
            } else if (playerMove.lastHorizontalInput < 0) {
                throwingKnifeProjectile.SetDirection(-knifeSpeed, 0f);
            } else {
                float X = playerMove.animator.GetFloat("X");
                if (X == 1) {
                    throwingKnifeProjectile.SetDirection(knifeSpeed, 0f);
                } else {
                    throwingKnifeProjectile.SetDirection(-knifeSpeed, 0f);
                }
            }
            throwingKnifeProjectile.damage = weaponStats.damage;
            }
    }
}
