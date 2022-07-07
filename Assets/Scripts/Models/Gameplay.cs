using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class Question
    {
        public string QuestionString;
        public string Answer;
        // NonReorderable Is only used to avoid overlap in the editor
        [NonReorderable]
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
