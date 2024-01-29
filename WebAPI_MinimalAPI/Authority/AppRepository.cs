namespace WebAPI_MinimalAPI.Authority
{
	public static class AppRepository
	{
		private static List<Application> _application = new List<Application>()
		{
			new Application {
				ApplicationId = 1,
				ApplicationName = "MVCWebApp",
				ClientId = "3543C19F-875C-4F3D-8351-E2EC3221625B",
				Secret = "919B8371-1133-44FD-B145-3F1B1A5759BD",
				Scopes = "read,write"
			}
		};

		public static bool Authenticate(string clientId, string secret) {
			return _application.Any(a => a.ClientId == clientId && a.Secret == secret);
		}

		public static Application? GetApplicationByClientId(string clientId)
		{
			return _application.FirstOrDefault(a => a.ClientId == clientId);
		}


	}
}
