using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Type type; // 건축물 타입

    public enum Type
    {
        Normal, // 건축물 아닌 것
        Wall,   // 벽
        Foundation, // 토대
        Pillar  // 기둥
    }
}
