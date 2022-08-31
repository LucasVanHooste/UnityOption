using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageExt;
using System;
using System.Threading.Tasks;

namespace UnityEngine
{
    [System.Serializable]
    public struct UnityOption<T>
    {
        [SerializeField] private T _value;

        //methods copied from Option<>
        public static Option<T> None => Option<T>.None;

        public bool IsSome => ((Option<T>)this).IsSome;
        public bool IsNone => ((Option<T>)this).IsNone;

        public static Option<T> Some(T value) => Option<T>.Some(value);
        public Option<T> Append(Option<T> rhs) => ((Option<T>)this).Append(rhs);
        public IEnumerable<T> AsEnumerable() => ((Option<T>)this).AsEnumerable();
        public int CompareTo(T other) => ((Option<T>)this).CompareTo(other);
        public int CompareTo(Option<T> other) => ((Option<T>)this).CompareTo(other);
        public Option<T> Divide(Option<T> rhs) => ((Option<T>)this).Divide(rhs);
        public bool Equals(T other) => ((Option<T>)this).Equals(other);
        public bool Equals(Option<T> other) => ((Option<T>)this).Equals(other);
        public override bool Equals(object obj) => ((Option<T>)this).Equals(obj);
        public override int GetHashCode() => ((Option<T>)this).GetHashCode();
        public Type GetUnderlyingType() => ((Option<T>)this).GetUnderlyingType();
        public T IfNone(Func<T> None) => ((Option<T>)this).IfNone(None);
        public T IfNone(T noneValue) => ((Option<T>)this).IfNone(noneValue);
        public T IfNoneUnsafe(Func<T> None) => ((Option<T>)this).IfNoneUnsafe(None);
        public T IfNoneUnsafe(T noneValue) => ((Option<T>)this).IfNoneUnsafe(noneValue);
        public Unit IfSome(Func<T, Unit> someHandler) => ((Option<T>)this).IfSome(someHandler);
        public Unit IfSome(Action<T> someHandler) => ((Option<T>)this).IfSome(someHandler);
        public Unit Match(Action<T> Some, Action None) => ((Option<T>)this).Match(Some, None);
        public R Match<R>(Func<T, R> Some, Func<R> None) => ((Option<T>)this).Match(Some, None);
        public Task<R> MatchAsync<R>(Func<T, Task<R>> Some, Func<Task<R>> None) => ((Option<T>)this).MatchAsync(Some, None);
        public Task<R> MatchAsync<R>(Func<T, Task<R>> Some, Func<R> None) => ((Option<T>)this).MatchAsync(Some, None);
        public IObservable<R> MatchObservable<R>(Func<T, IObservable<R>> Some, Func<R> None) => ((Option<T>)this).MatchObservable(Some, None);
        public IObservable<R> MatchObservable<R>(Func<T, IObservable<R>> Some, Func<IObservable<R>> None) => ((Option<T>)this).MatchObservable(Some, None);
        public R MatchUnsafe<R>(Func<T, R> Some, Func<R> None) => ((Option<T>)this).MatchUnsafe(Some, None);
        public R MatchUntyped<R>(Func<object, R> Some, Func<R> None) => ((Option<T>)this).MatchUntyped(Some, None);
        public Option<T> Multiply(Option<T> rhs) => ((Option<T>)this).Multiply(rhs);
        public SomeUnitContext<T> Some(Action<T> someHandler) => ((Option<T>)this).Some(someHandler);
        public SomeContext<T, R> Some<R>(Func<T, R> someHandler) => ((Option<T>)this).Some(someHandler);
        public Option<T> Subtract(Option<T> rhs) => ((Option<T>)this).Subtract(rhs);
        public T[] ToArray() => ((Option<T>)this).ToArray();
        public Either<L, T> ToEither<L>(Func<L> Left) => ((Option<T>)this).ToEither(Left);
        public Either<L, T> ToEither<L>(L defaultLeftValue) => ((Option<T>)this).ToEither(defaultLeftValue);
        public EitherUnsafe<L, T> ToEitherUnsafe<L>(Func<L> Left) => ((Option<T>)this).ToEitherUnsafe(Left);
        public EitherUnsafe<L, T> ToEitherUnsafe<L>(L defaultLeftValue) => ((Option<T>)this).ToEitherUnsafe(defaultLeftValue);
        public Lst<T> ToList() => ((Option<T>)this).ToList();
        public override string ToString() => ((Option<T>)this).ToString();
        public TryOption<T> ToTryOption<L>(L defaultLeftValue) => ((Option<T>)this).ToTryOption(defaultLeftValue);

        public static Option<T> operator +(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs + rhs;
        public static Option<T> operator -(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs - rhs;
        public static Option<T> operator *(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs * rhs;
        public static Option<T> operator /(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs / rhs;
        public static Option<T> operator |(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs | rhs;
        public static bool operator ==(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs == rhs;
        public static bool operator !=(UnityOption<T> lhs, Option<T> rhs) => (Option<T>)lhs != rhs;
        public static bool operator true(UnityOption<T> value) => value.IsSome;
        public static bool operator false(UnityOption<T> value) => value.IsNone;

        //extra operator to use this as an Option<> more easily
        public static implicit operator Option<T>(UnityOption<T> unityOption)
        {
            bool isSome = false;
            if (EqualityComparer<T>.Default.Equals(unityOption._value, default(T)))
            {
                isSome = false;
            }
            else
            {
                if (unityOption._value.GetType().IsValueType)
                {
                    isSome = true;
                }
                else
                {
                    switch (unityOption._value)
                    {
                        case Object obj: //this cast is needed or the option will have value null instead of being None
                            isSome = obj != null;
                            break;
                        case string s:
                            isSome = string.IsNullOrEmpty(s) == false;
                            break;
                        default:
                            isSome = unityOption._value != null;
                            break;
                    }
                }
            }

            return isSome ? Option<T>.Some(unityOption._value) : Option<T>.None;
        }
    } 
}
