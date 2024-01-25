using System.Text.Json;

namespace WebApp.Data
{
	public class WebApiExecuter : IWebApiExecuter
	{
		private const string apiName = "ShirtsApi";
		private readonly IHttpClientFactory _httpClientFactory;

		public WebApiExecuter(IHttpClientFactory httpClientFactory)
		{
			this._httpClientFactory = httpClientFactory;
		}

		public async Task<T?> InvokeGet<T>(string relativeUrl)
		{
			var httpClient = _httpClientFactory.CreateClient(apiName);
			var request = new HttpRequestMessage(HttpMethod.Get, relativeUrl);
			var response = await httpClient.SendAsync(request);
			await handleError(response);
			//return await httpClient.GetFromJsonAsync<T>(relativeUrl);
			return await response.Content.ReadFromJsonAsync<T>();
		}

		public async Task<T?> InvokePost<T>(string relativeUrl, T obj)
		{
			var httpClient = _httpClientFactory.CreateClient(apiName);
			var response = await httpClient.PostAsJsonAsync(relativeUrl, obj);
			//response.EnsureSuccessStatusCode();

			//if (!response.IsSuccessStatusCode) {
			//   var errorJson = await response.Content.ReadAsStringAsync();
			//	throw new WebApiException(errorJson);               
			//}
			await handleError(response);
			return await response.Content.ReadFromJsonAsync<T>();
		}

		public async Task InvokePut<T>(string relativeUrl, T obj)
		{
			var httpClient = _httpClientFactory.CreateClient(apiName);
			var response = await httpClient.PutAsJsonAsync(relativeUrl, obj);
			//response.EnsureSuccessStatusCode();
			await handleError(response);
		}

		public async Task InvokeDelete(string relativeUrl)
		{
			var httpClient = _httpClientFactory.CreateClient(apiName);
			var response = await httpClient.DeleteAsync(relativeUrl);
			//response.EnsureSuccessStatusCode();
			await handleError(response);
		}

		private async Task handleError(HttpResponseMessage response) {
			if (!response.IsSuccessStatusCode)
			{
				var errorJson = await response.Content.ReadAsStringAsync();
				throw new WebApiException(errorJson);
			}
		}
	}
}
