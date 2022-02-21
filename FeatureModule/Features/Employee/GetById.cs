using FeatureModule.Extensions;

namespace FeatureModule.Features.Employee;

public class GetById : IFeature
{
	public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoint)
	{
		endpoint.MapGet("/employee/{id}", async (int id) => {
				var handler = new Handler();
				return await handler.Handle(new Query(id));
			})
			.WithName("Get Employee By Id")
			.Produces<Response>(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status404NotFound);

		return endpoint;
	}

	public record Query(int Id);

	public record Response(int Id, string Name);
	
	public class Handler
	{
		public async Task<IResult> Handle(Query request, CancellationToken cancellationToken = default)
		{
			var data = DbExample.GetData();
			var employee = data.FirstOrDefault(x => x.Id == request.Id);
			if (employee is null)
				return Results.NotFound();

			var response = new Response(employee.Id, employee.Name);
			
			return await Task.FromResult(Results.Ok(response));
		}
	}
}
