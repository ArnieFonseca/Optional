
namespace Functional.Optional;
/// <summary>
/// Represents an absent of a value from the ancestor Optional Type
/// </summary>
/// <typeparam name="T">Not used in the case of None</typeparam>
public class None<T> : Optional<T>
{
    /// <summary>
    /// Constructor of the None Optional Type
    /// </summary>
    public None() : base(default) => isHasValue = false;
    /// <summary>
    /// Pass Nothing since None has no value
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="fn"></param>
    /// <returns></returns>
    public override Optional<U> Bind<U>(Func<T, Optional<U>> fn) => new None<U>();
    public override U Match<U>(Func<T, U> fn_some, Func<T, U> fn_none) => fn_none(value);
}
