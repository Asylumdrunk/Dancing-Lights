using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCounter : MonoBehaviour
{
    public int _lightCounter;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _lightCounter = 0;
    }

}
