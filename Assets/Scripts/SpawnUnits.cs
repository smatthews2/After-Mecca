using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    public GameObject[] UnitType = new GameObject[3];
    public GameObject UnitContainer;
    [SerializeField] private int amount;
    [SerializeField] private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateUnit(amount);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void CreateUnit(int unitNum)
    {
        for(int i = 0;  i < unitNum; i++)
        {
            GameObject FootmanClone = Instantiate(UnitType[index], new Vector3(i, 0f, 0), UnitType[index].transform.rotation);
            FootmanClone.transform.parent = UnitContainer.transform;
            FootmanClone.name = UnitType[index].name + "Clone " + (i + 1);
        }
    }
}
