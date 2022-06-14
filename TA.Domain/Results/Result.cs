using System;

namespace TA.Domain.Results
{
    public class Result
    {
        public String? Error { get; }
        public Boolean IsSuccess => Error is null;

        public static Result Success() => new Result(null);
        public static Result Fail(String error) => new Result(error);

        private Result(String? error) => Error = error;
    }
}
