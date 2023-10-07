using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Input.inputString)
        {
            case "1":
                SceneManager.LoadScene("Battle");
                break;
            case "2":
                SceneManager.LoadScene("Map");
                break;
            default:
                return;
        }
    }
}
