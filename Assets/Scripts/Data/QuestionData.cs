using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestionData", menuName = "Data/Question")]
public class QuestionData : ScriptableObject
{
    public string QuestionContent;
    public List<string> QuestionOptions;
    public int AnswerIndex;
}
