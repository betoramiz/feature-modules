namespace FeatureModule.Extensions;

public static class RegisterFeatures
{
	public static void RegisterFeatureModules(this WebApplication webApplication)
	{
		var features = DiscoverFeatures();
		foreach (var feature in features)
		{
			feature.RegisterEndpoints(webApplication);
		}
	}

	private static IEnumerable<IFeature> DiscoverFeatures() =>
		typeof(IFeature).Assembly
			.GetTypes()
			.Where(p => p.IsClass && p.IsAssignableTo(typeof(IFeature)))
			.Select(Activator.CreateInstance)
			.Cast<IFeature>();

}
