using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskAppFinal.Models;
using Xamarin.Essentials;

namespace TaskAppFinal.API
{
	public class ApiClient
	{
        private readonly HttpClient _httpClient;

        private string _token;
        public string Token { get { return _token; } }

        public ApiClient()
		{
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true
            };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri("https://taskmanager-project-fall2022-zmoya.ondigitalocean.app/v1/");
        }

		public async Task<string> SignUp(string name, string email, string password)
		{
			dynamic data = new { name, email, password };
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("users/signup", stringContent);
			
            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

			if (response.IsSuccessStatusCode)
			{
				return body["uid"].ToString();
			}
			else
			{
				throw new Exception(body["error"].ToString());
			}
		}

        public async Task<User> SignIn(string email, string password)
        {
            dynamic data = new { email, password };
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("users/login", stringContent);

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                var loggedUser = body["loggedUser"];
                var token = body["token"].ToString();

                _httpClient.DefaultRequestHeaders.Add("x-access-token", token);
                _token = token;

                return new User
                {
                    UID = loggedUser["uid"].ToString(),
                    Email = loggedUser["email"].ToString(),
                    Name = loggedUser["name"].ToString()
                };
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("users/all");

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                List<User> users = new List<User>();

                foreach (var user in body["allUsers"])
                {
                    users.Add(new User
                    {
                        UID = user["uid"].ToString(),
                        Email = user["email"].ToString(),
                        Name = user["name"].ToString()
                    });
                }

                return users;
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task<string> CreateTask(string description, string assignedToUid)
        {
            dynamic data = new { description, assignedToUid };
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("tasks", stringContent);

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                return body["id"].ToString();
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task<List<AssignedTask>> GetTasksCreatedBy()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("tasks/createdby");

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                List<AssignedTask> tasks = new List<AssignedTask>();

                foreach (var task in body["allTasks"])
                {
                    tasks.Add(new AssignedTask()
                    {
                        AssignedToName = task["assignedToName"].ToString(),
                        AssignedToUid = task["assignedToUid"].ToString(),
                        CreatedByName = task["createdByName"].ToString(),
                        CreatedByUid = task["createdByUid"].ToString(),
                        Description = task["description"].ToString(),
                        Done = task["done"].ToString(),
                        TaskUid = task["taskUid"].ToString()
                    });
                }

                return tasks;
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task<List<AssignedTask>> GetTasksAssignedTo()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("tasks/assignedto");

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                List<AssignedTask> tasks = new List<AssignedTask>();

                foreach (var task in body["allTasks"])
                {
                    tasks.Add(new AssignedTask()
                    {
                        AssignedToName = task["assignedToName"].ToString(),
                        AssignedToUid = task["assignedToUid"].ToString(),
                        CreatedByName = task["createdByName"].ToString(),
                        CreatedByUid = task["createdByUid"].ToString(),
                        Description = task["description"].ToString(),
                        Done = task["done"].ToString(),
                        TaskUid = task["taskUid"].ToString()
                    });
                }

                return tasks;
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task<string> UpdateTask(string taskUid, bool done)
        {
            dynamic data = new { done };
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), "tasks/" + taskUid);
            request.Content = stringContent;
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (response.IsSuccessStatusCode)
            {
                return body["taskUid"].ToString();
            }
            else
            {
                throw new Exception(body["error"].ToString());
            }
        }

        public async Task DeleteTask(string taskUid)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("tasks/" + taskUid);

            string content = await response.Content.ReadAsStringAsync();
            var body = JObject.Parse(content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(body["error"].ToString());
            }
        }
    }
}

