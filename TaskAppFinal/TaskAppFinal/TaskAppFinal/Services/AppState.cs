using System;
using TaskAppFinal.API;
using TaskAppFinal.Models;

namespace TaskAppFinal.Services
{
	public class AppState
	{
		private static AppState _instance;

		public User User { get; set; }
		public ApiClient ApiClient { get; set; }

		public AppState()
		{
			User = null;
			ApiClient = new ApiClient();
		}

		public static AppState GetInstance()
		{
			if (_instance == null)
			{
				_instance = new AppState();
				return _instance;
			}

			return _instance;
		}
	}
}

