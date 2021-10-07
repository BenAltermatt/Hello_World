using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TechnicalEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Editor causes this awake.");
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
