using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Type type; // ���๰ Ÿ��

    public enum Type
    {
        Normal, // ���๰ �ƴ� ��
        Wall,   // ��
        Foundation, // ���
        Pillar  // ���
    }
}
