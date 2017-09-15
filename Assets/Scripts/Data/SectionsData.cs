using UnityEngine;
[CreateAssetMenu(fileName = "SectionsData", menuName = "Data/Sections")]

public class SectionsData : ScriptableObject
{
    [System.Serializable]
    public class SectionItemData
    {
        public string SectionName;
        public string SceneName;
        public Sprite SectionSprite_Forward;
        public Sprite SectionSprite_Back;
    }

    public SectionItemData[] SectionItems;
}
