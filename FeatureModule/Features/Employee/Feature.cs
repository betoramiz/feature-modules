using FeatureModule.Extensions;
using FluentValidation;

namespace FeatureModule.Features.Employee;

public class Feature //: IFeature
{
	// public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoint)
	// {
	// 	endpoint.MapGet("/employees", GetList);
	// 	endpoint.MapGet("/employee/{id}", GetById);
	// 	endpoint.MapPost("/employee/create", Create);
	//
	// 	return endpoint;
	// }
	//
	// private async Task<IResult> GetById(int id)
	// {
	// 	var request = new GetById.Query(id);
	// 	var handler = new GetById.Handler();
	// 	return await handler.Handle(request);
	// }
	//
	// private async Task<IResult> GetList()
	// {
	// 	var handler = new List.Handler();
	// 	return await handler.Handle();
	// }
	//
	// private async Task<IResult> Create(Create.Command request, IValidator<Create.Command> validator)
	// {
	// 	var handler = new Create.Handler(validator);
	// 	return await handler.Handle(request);
	// }
}
