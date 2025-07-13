using MadeYellow.AnimatorParameter.Abstractions;
using UnityEngine;

namespace MadeYellow.AnimatorParameter
{
    /// <summary>
    /// A <see cref="bool"/>-parameter
    /// </summary>
    public class BooleanParameter : ValueAnimatorParameterBase<bool>
    {
        public BooleanParameter(string codename, Animator animator) : base(codename, animator)
        {
        }

        protected override bool ReadValue()
        {
            return Animator.GetBool(Code);
        }

        protected override void WriteValue(bool value)
        {
            Animator.SetBool(Code, value);
        }
    }
}