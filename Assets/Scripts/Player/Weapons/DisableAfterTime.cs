using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDisable = 0.2f;
    float timer;

    private void OnEnable()
    {
        timer = timeToDisable;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) {
            gameObject.SetActive(false);
        }
    }
}
