using UnityEngine;

namespace MadeYellow.AnimatorParameter.Abstractions
{
    /// <summary>
    /// A base of a parameter that will pass some value into the <see cref="Animator"/>
    /// </summary>
    /// <typeparam name="T">Tpe of a value to pas into the <see cref="Animator"/></typeparam>
    public abstract class ValueAnimatorParameterBase<T> : AnimatorParameterBase where T : struct
    {
        public T Value { get => GetValue(); set => SetValue(value); }

        private T _valueCache;

        protected ValueAnimatorParameterBase(string codename, Animator animator) : base(codename, animator)
        {
        }

        protected virtual T GetValue()
        {
            return ReadValue();
        }

        private void SetValue(T value)
        {
            if (_valueCache.Equals(value))
                return;

            _valueCache = value;

            WriteValue(value);
        }

        protected abstract T ReadValue();

        protected abstract void WriteValue(T value);
    }
}