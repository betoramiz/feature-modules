using FeatureModule.Extensions;
using FluentValidation;

namespace FeatureModule.Features.Employee;

public class Create: IFeature
{
	public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoint)
	{
		endpoint.MapPost("/employee", async (IValidator<Command> validator, Command request) => {
				var handler = new Handler(validator);
				return await handler.Handle(request);
			})
			.WithName("Create Employee")
			.Produces<int>(StatusCodes.Status201Created)
			.ProducesValidationProblem();
		
		return endpoint;
	}

	public record Command(string Name);

	public class Validations: AbstractValidator<Command>
	{
		public Validations()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
	
	public class Handler
	{
		private readonly IValidator<Command> _validator;
		public Handler(IValidator<Command> validator) => _validator = validator;

		public async Task<IResult> Handle(Command request, CancellationToken cancellationToken = default)
		{
			var validation = _validator.Validate(request);
			if(!validation.IsValid)
				return Results.ValidationProblem(validation.ToValidationProblems());

			var data = DbExample.GetData();
			var employee = new Models.Employee()
			{
				Id = data.Max(x => x.Id) + 1,
				Name = request.Name
			};
			
			data.Add(employee);
			return await Task.FromResult(Results.CreatedAtRoute("Get Employee By Id", new { id = employee.Id}));
		}
	}
}
