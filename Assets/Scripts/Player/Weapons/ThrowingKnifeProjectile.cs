using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;

    float ttl = 6f;
    
    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0) {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    bool hitDetected = false;
    private void Update() {
        transform.position += speed * Time.deltaTime * direction;

        if (Time.frameCount % 6 == 0) {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
            foreach (Collider2D c in hit) {
                if (c.TryGetComponent<Enemy>(out var enemy)) {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }

            if (hitDetected) {
                Destroy(gameObject);
            }
        }

        ttl -= Time.deltaTime;
        if (ttl < 0f) {
            Destroy(gameObject);
        }
    }
}
