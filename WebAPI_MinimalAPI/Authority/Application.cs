﻿namespace WebAPI_MinimalAPI.Authority
{
	public class Application
	{
        public int ApplicationId { get; set; }
		public string? ApplicationName { get; set; }
        public string? ClientId { get; set; }
        public string? Secret { get; set; }
        public string? Scopes { get; set; }
    }
}
