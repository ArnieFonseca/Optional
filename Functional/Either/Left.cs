
namespace Functional.Either;
 
public class Left<TLeft, TRight> : Either<TLeft, TRight>
{
    public Left(TLeft value) : base(value, default) => isLeft = true;

    public override Either<TLeft, T1Right> Bind<T1Right>(Func<TRight, Either<TLeft, T1Right>> fn) => new Left<TLeft, T1Right>(leftValue);

    public override TResult Match<TResult>(Func<TRight, TResult> fn_right, Func<TLeft, TResult> fn_left) => fn_left(leftValue);

}
