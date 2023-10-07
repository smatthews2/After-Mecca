using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    public GameObject FootmanOriginal;
    public GameObject UnitContainer;
    [SerializeField] private int amount;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateFootman(amount);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void CreateFootman(int unitNum)
    {
        for(int i = 0;  i < unitNum; i++)
        {
            GameObject FootmanClone = Instantiate(FootmanOriginal, new Vector3(i, 0f, 0), FootmanOriginal.transform.rotation);
            FootmanClone.transform.parent = UnitContainer.transform;
            FootmanClone.name = "FootmanClone " + (i + 1);
        }
    }
}
