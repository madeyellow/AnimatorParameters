using UnityEngine;

namespace MadeYellow.AnimatorParameter.Abstractions
{
    /// <summary>
    /// A base for a <see cref="Animator"/>'s parameter
    /// </summary>
    public abstract class AnimatorParameterBase
    {
        /// <summary>
        /// Hash-code of a <see cref="Animator"/>'s parameter
        /// </summary>
        protected readonly int Code;

        /// <summary>
        /// An <see cref="Animator"/> to pass parameter value into
        /// </summary>
        protected readonly Animator Animator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codename">A name of a parameter to pass value into. Must be identical to the parameter defined in <see cref="Animator"/></param>
        /// <param name="animator">An <see cref="Animator"/> to pass parameter value into</param>
        public AnimatorParameterBase(string codename, Animator animator)
        {
            // Empty code aren'y allowed
            if (string.IsNullOrWhiteSpace(codename))
            {
                throw new System.ArgumentException($"'{nameof(codename)}' cannot be null or whitespace.", nameof(codename));
            }

            Code = Animator.StringToHash(codename);
            Animator = animator ?? throw new System.ArgumentNullException(nameof(animator));// Null value aren't allowed
        }
    }
}