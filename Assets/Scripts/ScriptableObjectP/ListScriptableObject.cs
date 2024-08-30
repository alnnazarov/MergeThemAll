using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ListScriptableObject", order = 2)]
public class ListScriptableObject : ScriptableObjectAbstract
{
    [SerializeField] private List<GameObject> list;
    
    public List<GameObject> GetList()
    {
        return list;
    }
}
