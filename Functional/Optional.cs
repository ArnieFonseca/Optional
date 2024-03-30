
namespace Functional.Optional;
/// <summary>
/// The Optional type encapsulates represents the possibility of an absent of a  value. 
/// A value of type Optional a either contains a value of type a (represented as Some a), or it is empty (represented as None). 
/// Using Optional is a good way to deal with errors or exceptional cases without resorting to drastic measures such as error.
/// </summary>
/// <typeparam name="T">A parametric type of the value</typeparam>
/// <param name="value">The contained value of the Optional</param>
public abstract class Optional<T>(T value)
{
    protected T value = value;
    protected bool isHasValue;

    public bool IsHasValue
    {
        get { return this.isHasValue; }
    }
    /// <summary>
    /// Takes a value and produces an Optional Type
    /// </summary>
    /// <param name="value"></param>
    /// <returns>An Optional Type containing the passed value</returns>
    public static Optional<T> Unit(T value)
    {
        return new Some<T>(value);
    }
    /// <summary>
    /// Uses for function sequential composition
    /// </summary>
    /// <typeparam name="U">Output of the Optional Type</typeparam>
    /// <param name="fn">Transformation function</param>
    /// <returns>Optional Type</returns>
    public abstract Optional<U> Bind<U>(Func<T, Optional<U>> fn);
    /// <summary>
    /// Retrieve either Some value or None
    /// </summary>
    /// <typeparam name="U">Output type</typeparam>
    /// <param name="fn_some">Function to retrieve a value</param>
    /// <param name="fn_none">Function when there is no value</param>
    /// <returns></returns>
    public abstract U Match<U>(Func<T, U> fn_some, Func<T, U> fn_none);

}
