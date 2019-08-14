using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLPC : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
