using MadeYellow.AnimatorParameter.Abstractions;
using UnityEngine;

namespace MadeYellow.AnimatorParameter
{
    /// <summary>
    /// An <see cref="int"/>-parameter
    /// </summary>
    public class IntegerParameter : ValueAnimatorParameterBase<int>
    {
        public IntegerParameter(string codename, Animator animator) : base(codename, animator)
        {
        }

        protected override int ReadValue()
        {
            return Animator.GetInteger(Code);
        }

        protected override void WriteValue(int value)
        {
            Animator.SetInteger(Code, value);
        }
    }
}