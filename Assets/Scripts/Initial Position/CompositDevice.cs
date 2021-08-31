using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartPosition
{
    public class CompositDevice : MonoBehaviour
    {
        //части основого объекта не добавл€ютс€ в лист 
        //класса InitialPositionDisplay
        //добавл€ть их нужно здесь в пор€дке иерархии
        public List<GameObject> CompositPrefabs;
    }
}
