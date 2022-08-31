using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class Question
    {
        [Tooltip("The question to ask the user")]
        public string QuestionString;
        [Tooltip("The correct answer to this question")]
        public string Answer;
        // NonReorderable Is only used to avoid overlap in the editor
        [NonReorderable]
        [Tooltip("All the possible (but wrong) answers")]
        public string[] OtherOptions;

        public override string ToString()
        {
            // TODO
            return QuestionString;
        }
    }

    public abstract class ClassWithName
    {
        public string Name;

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class Level : ClassWithName
    {
        //public string Name;
        public string Url;
        public Question Question;
    }

    [Serializable]
    public class Theme : ClassWithName
    {
        //public string Name;
        // NonReorderable Is only used to avoid overlap in the editor
        [NonReorderable]
        public Level[] Levels;
    }
}
