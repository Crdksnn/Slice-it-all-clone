using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] GameObject startText;

    void Start()
    {
        
    }

    
    void Update()
    {
        if ( startText != null && Input.GetMouseButtonDown(0))
        {
            Destroy(startText);
        }
    }
}
