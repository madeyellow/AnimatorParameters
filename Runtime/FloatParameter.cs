using MadeYellow.AnimatorParameter.Abstractions;
using UnityEngine;

namespace MadeYellow.AnimatorParameter
{
    /// <summary>
    /// A <see cref="float"/>-parameter
    /// </summary>
    public class FloatParameter : ValueAnimatorParameterBase<float>
    {
        public FloatParameter(string codename, Animator animator) : base(codename, animator)
        {
        }

        protected override float ReadValue()
        {
            return Animator.GetFloat(Code);
        }

        protected override void WriteValue(float value)
        {
            Animator.SetFloat(Code, value);
        }
    }
}