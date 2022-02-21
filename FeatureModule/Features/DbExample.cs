namespace FeatureModule.Features;

public static class DbExample
{
	public static List<Models.Employee> GetData() =>
		new List<Models.Employee>()
		{
			new Models.Employee() { Id = 1, Name = "Alberto" },
			new Models.Employee() { Id = 2, Name = "Ramirez" },
			new Models.Employee() { Id = 3, Name = "Rebeca" },
			new Models.Employee() { Id = 4, Name = "Estada" },
			new Models.Employee() { Id = 5, Name = "Empleado 1" },
			new Models.Employee() { Id = 6, Name = "Gato" }
		};
}
