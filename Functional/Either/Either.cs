using Functional.Optional;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Either
{
    public abstract class Either<TLeft,TRight>
    {
        protected readonly TRight rightValue;
        protected readonly TLeft leftValue;
        protected bool isLeft;
        protected bool isRight;

        public Either(TLeft l, TRight r)
        {
            rightValue = r;
            leftValue = l;

        }
        public bool IsLeft => isLeft;
        public bool IsRight => isRight;
        public static Either<TLeft,TRight> Unit(TRight value) => new Right<TLeft,TRight>(value);
        public abstract Either<TLeft,TRight1> Bind<TRight1>(Func<TRight, Either<TLeft,TRight1>> fn);
        public abstract TResult Match<TResult>(Func<TRight, TResult> fn_right, Func<TLeft, TResult> fn_left);
        public  Either<Exception, TResult> TryCatch<TResult>(Func<TRight, Either<Exception, TResult>> fn)
        {
            try
            {
                return fn(this.rightValue);
            }
            catch (Exception e)
            {
                return new Left<Exception, TResult>(e); ;
            }
        }

    }
}
