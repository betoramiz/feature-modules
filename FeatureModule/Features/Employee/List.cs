using FeatureModule.Extensions;

namespace FeatureModule.Features.Employee;

public class List: IFeature
{
	public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoint)
	{
		endpoint.MapGet("/employees", async () => {
			var handler = new Handler();
			return await handler.Handle(new Query());
		})
			.WithName("List Of Employees")
			.Produces<List<Result>>(StatusCodes.Status200OK);
		return endpoint;
	}

	public record Query();

	public record Result(int Id, string Name);

	public class Handler
	{
		public async Task<IResult> Handle(Query request, CancellationToken cancellationToken = default)
		{
			var data = DbExample.GetData();
			var result = data.Select(x => new Result(x.Id, x.Name)).ToList();
			return await Task.FromResult(Results.Ok(result));
		}
	}
}
