
namespace Functional.Optional;

public class None<T> : Optional<T>
{
    public None() : base(default) => isHasValue = false;

    public override Optional<U> Bind<U>(Func<T, Optional<U>> fn) => new None<U>();
    public override U Match<U>(Func<T, U> fn_some, Func<T, U> fn_none) => fn_none(value);
}
