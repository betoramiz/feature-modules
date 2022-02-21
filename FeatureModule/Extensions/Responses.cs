namespace FeatureModule.Extensions;

public class Responses
{
	public enum ResultStatus
	{
		Success, Failure
	}

	public ResultStatus Status { get; internal set; }
	
	protected Responses(ResultStatus resultStatus)
	{
		Status = resultStatus;
	}

	public static Responses Success()
	{
		return new Responses(ResultStatus.Success);
	}
	
	public static Responses<T> Success<T>(T value)
	{
		if (value is null) throw new ArgumentException(null, nameof(value));
		
		return new Responses<T>(value, ResultStatus.Success);
	}

	public static Responses Failure()
	{
		return new Responses(ResultStatus.Failure);
	}
	
	public static Responses<T?> Failure<T>()
	{
		return new Responses<T?>(default, ResultStatus.Failure);
	}
}

public class Responses<T> : Responses
{
	public T Value { get; }
	
	protected internal Responses(T value, ResultStatus resultStatus) : base(resultStatus)
	{
		Status = resultStatus;
		Value = value;
	}
}
