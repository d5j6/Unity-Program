using UnityEngine;
[CreateAssetMenu(fileName = "LessonsData", menuName = "Data/Lessons")]
public class LessonsData : ScriptableObject
{
    [System.Serializable]
    public class LessonItemData
    {
        public string LessonName;
        public string SceneName;
        public Sprite LessonSprite;
        public Sprite LessonTitleSprite;
        public string[] SectionNames;
    }

    public LessonItemData[] LessonItems;
}
