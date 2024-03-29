﻿namespace WebApp.Data
{
	public interface IWebApiExecuter
	{
		Task InvokeDelete(string relativeUrl);
		public Task<T?> InvokeGet<T>(string relativeUrl);
		public Task<T?> InvokePost<T>(string relativeUrl, T obj);
		public Task InvokePut<T>(string relativeUrl, T obj);
	}
}