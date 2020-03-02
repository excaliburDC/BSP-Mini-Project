using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story",menuName ="Stories")]
public class Story : ScriptableObject
{
    [TextArea(3,10)]
    public List<string> sentences;
}
