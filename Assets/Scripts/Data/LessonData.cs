using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LessonData", menuName = "Data/Lesson")]
public class LessonData : ScriptableObject
{
    public string LessonName;

    public List<SectionData> Sections;
}


