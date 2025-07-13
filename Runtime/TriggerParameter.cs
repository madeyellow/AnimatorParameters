using MadeYellow.AnimatorParameter.Abstractions;
using UnityEngine;

namespace MadeYellow.AnimatorParameter
{
    /// <summary>
    /// A trigger-parameter
    /// </summary>
    public class TriggerParameter : AnimatorParameterBase
    {
        public TriggerParameter(string codename, Animator animator) : base(codename, animator)
        {
        }

        public TriggerParameter Trigger()
        {
            Animator.SetTrigger(Code);

            return this;
        }

        public TriggerParameter Reset()
        {
            Animator.ResetTrigger(Code);

            return this;
        }
    }
}