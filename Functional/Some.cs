
namespace Functional.Optional;

public class Some<T> : Optional<T>
{

    public Some(T value) : base(value) { this.isHasValue = true; }

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
