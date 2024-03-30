﻿

''



















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































namespace Functional.Optional;

public abstract class Optional<T>(T value)
{
    protected T value = value;
    protected bool isHasValue;

    public bool IsHasValue
    {
        get { return this.isHasValue; }
    }
    public static Optional<T> Unit(T value)
    {
        return new Some<T>(value);
    }
    public abstract Optional<U> Bind<U>(Func<T, Optional<U>> fn);
    public abstract U Match<U>(Func<T, U> fn_some, Func<T, U> fn_none);

}