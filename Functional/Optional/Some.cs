
namespace Functional.Optional;
/// <summary>
/// Represent the existence of a value of an Optional Type
/// </summary>
/// <typeparam name="T">A parametric type of the value</typeparam>
public class Some<T> : Optional<T>
{
    /// <summary>
    /// Constructor for the Some Type
    /// </summary>
    /// <param name="value">The internal value of the Optional Type</param>
    public Some(T value) : base(value) => isHasValue = true;

    public override Optional<U> Bind<U>(Func<T, Optional<U>> fn)
    {
        try
        {
            return fn(value);
        }
        catch
        {

            return new None<U>();
        }
    }

    public override U Match<U>(Func<T, U> fn_some, Func<T, U> fn_none) => fn_some(value);
}
