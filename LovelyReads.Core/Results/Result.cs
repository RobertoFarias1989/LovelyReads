using LovelyReads.Core.Errors;

namespace LovelyReads.Core.Results;

public class Result : ResultBase
{
    protected Result() { }

    protected Result(IError error)
    {
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        _errors.AddRange(errors);
    }

    public static Result Ok() => new Result();
    public static Result Fail(IError error) => new Result(error);
    public static Result Fail(IEnumerable<IError> errors) => new Result(errors);

    public static Result<TValue> Ok<TValue>(TValue value) => Result<TValue>.Ok(value);
    public static Result<TValue> Fail<TValue>(IError error) => Result<TValue>.Fail<TValue>(error);
    public static Result<TValue> Fail<TValue>(IEnumerable<IError> errors) => Result<TValue>.Fail<TValue>(errors);
}

public class Result<TValue> : ResultBase<TValue>
{
    protected Result(TValue value)
    {
        _value = value;
    }

    protected Result(IError error)
    {
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors == null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        _errors.AddRange(errors);
    }

    public static Result<TValue> Ok<TValue>(TValue value) => new Result<TValue>(value);
    public static Result<TValue> Fail<TValue>(IError error) => new Result<TValue>(error);
    public static Result<TValue> Fail<TValue>(IEnumerable<IError> errors) => new Result<TValue>(errors);
}