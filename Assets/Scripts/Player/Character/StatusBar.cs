using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Transform bar;

    //set hp    
    public void SetState(int current, int max)
    {
        float state = (float) current;
        state /= max; //convert value within 0 and 1

        if (state < 0f) {
            state = 0f;
        }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
