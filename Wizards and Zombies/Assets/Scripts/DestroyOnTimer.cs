using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    [SerializeField] float timer;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            Destroy(gameObject);
        }
    }
}
