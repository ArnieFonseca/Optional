
namespace Functional.Either;

public class Right<TLeft, TRight> : Either<TLeft, TRight>
{

    public Right(TRight value) : base(default, value) => isRight = true;

    public override Either<TLeft, T1Right> Bind<T1Right>(Func<TRight, Either<TLeft, T1Right>> fn) => fn(rightValue);

    public override TResult Match<TResult>(Func<TRight, TResult> fn_right, Func<TLeft, TResult> fn_left) => fn_right(rightValue);


}
