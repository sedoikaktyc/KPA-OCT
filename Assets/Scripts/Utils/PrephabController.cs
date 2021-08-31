using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class PrephabController : MonoBehaviour
    {
        public static PrephabController instance;

        [SerializeField]
        private List<GameObject> _prefabs;

        private List<GameObject> _instantiatePrefabs = new List<GameObject>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            if (_prefabs != null)
            {
                foreach (var prefab in _prefabs)
                {
                    var instantiateGameObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    DontDestroyOnLoad(instantiateGameObject);
                    _instantiatePrefabs.Add(instantiateGameObject);
                }
            }

        }

        //объекты стартового экрана должны удаляться до его повторной загрузки
        public void DestroySerialPortPrefabs()
        {
            foreach (var objects in _instantiatePrefabs)
            {
                Destroy(objects);
            }
        }
    }
}