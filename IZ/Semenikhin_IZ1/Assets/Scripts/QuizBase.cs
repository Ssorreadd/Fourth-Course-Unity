using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionBase", menuName = "QuestionBase")]
public class QuizBase : ScriptableObject
{
    public List<QuestionType> questions;
}
