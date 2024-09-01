using UnityEngine;

namespace ScriptableObjectP
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TransformScriptableObject", order = 1)]
    public class TransformScriptableObject : ScriptableObjectAbstract
    {
        [SerializeField] private Transform transform;

        public Transform GetTransform()
        {
            return transform;
        }
    }
}