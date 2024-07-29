using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float TimeToLive = 1.5f;
    float ttl = 1.5f;

    private void OnEnable() {
        ttl = TimeToLive;
    }

    private void Update() {
        ttl -= Time.deltaTime;
        if (ttl < 0f) {
            gameObject.SetActive(false);
        }
    }
}
