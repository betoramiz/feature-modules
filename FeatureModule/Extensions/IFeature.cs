namespace FeatureModule.Extensions;

public interface IFeature
{
	public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoint);
}
