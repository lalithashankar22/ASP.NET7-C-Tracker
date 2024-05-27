using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using Tracker.web.Models;
using Tracker.web.Models.DTO;

namespace Tracker.web.Controllers
{
    public class DepartmentViewController : Controller
    {
        private IHttpClientFactory httpClientFactory;

        public DepartmentViewController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult loginPage()
        {
            return View();
        }

       public async Task<return1> login(LoginModel loginDetails)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDetails.userid) && string.IsNullOrEmpty(loginDetails.password))
                {
                    return null;
                }
                var client = httpClientFactory.CreateClient();
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7011/api/Auth/login"),
                    Content = new StringContent(JsonSerializer.Serialize(loginDetails), System.Text.Encoding.UTF8, "application/json")
                };
                var httpResponseMessage = await client.SendAsync(request);
                httpResponseMessage.EnsureSuccessStatusCode();
                var reponse = await httpResponseMessage.Content.ReadFromJsonAsync<response>();
                if (reponse != null)
                {
                    var return1 = new return1();
                    return1.userid = loginDetails.userid;
                    return1.password = loginDetails.password;
                    return1.jwt = reponse.jwtToken;

                    return return1;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public async Task<IActionResult> Index()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            try
            {
                LoginModel LoginModel = new LoginModel
                {
                    userid ="writer@example.com",
                   password ="writer@123"
                };
                return1 token = await login(LoginModel);


                //get depatment from WEB API
                var client = httpClientFactory.CreateClient();
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7011/api/Department"),
                };
                if(token != null) { 
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);
                }
                var httpResponseMessage = await client.SendAsync(request);
                // var httpResponseMessage = await client.GetAsync("https://localhost:7011/api/Department");
                httpResponseMessage.EnsureSuccessStatusCode();
                //var responseBody = await httpResponseMessage.Content.ReadAsStringAsync(); // before dto
                //var responseBody = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<DepartmentDTO>>();
                // ViewBag.Response = responseBody;
                departments.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<DepartmentDTO>>());
            }
            catch (Exception ex)
            {
                //log exception
            }
            return View(departments);
        }
    
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDepartmentModel model)
        {
            var client = httpClientFactory.CreateClient();
            var request = new HttpRequestMessage() 
            { 
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7011/api/Department"),
                Content = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json")
            };
            LoginModel LoginModel = new LoginModel
            {
                userid = "writer@example.com",
                password = "writer@123"
            };
            return1 token = await login(LoginModel);
            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);
            }

            var response =  await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var endResult = await response.Content.ReadFromJsonAsync<DepartmentDTO>();
            if (endResult != null)
            {

                return RedirectToAction("Index", "DepartmentView");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.department_id = id;
            DepartmentDTO departments = new DepartmentDTO();
            try
            {
                var client = httpClientFactory.CreateClient();
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7011/api/Department/" + id)
                };
                LoginModel LoginModel = new LoginModel
                {
                    userid = "writer@example.com",
                    password = "writer@123"
                };
                return1 token = await login(LoginModel);
                if (token != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);
                }

                var httpResponseMessage = await client.SendAsync(request);
                httpResponseMessage.EnsureSuccessStatusCode();
                departments = await httpResponseMessage.Content.ReadFromJsonAsync<DepartmentDTO>();
            }
            catch (Exception ex)
            {
                //log exception
            }
            return View(departments);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentDTO department)
        {
            var client = httpClientFactory.CreateClient();

            AddDepartmentModel bodydept = new AddDepartmentModel();
            bodydept.dept_name = department.dept_name;
            bodydept.archv_flag = department.archv_flag;

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7011/api/Department"),
                Content = new StringContent(JsonSerializer.Serialize(bodydept), System.Text.Encoding.UTF8, "application/json")
            };
            LoginModel LoginModel = new LoginModel
            {
                userid = "writer@example.com",
                password = "writer@123"
            };
            return1 token = await login(LoginModel);
            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);
            }

            request.Headers.Add("id", department.dept_id.ToString());
            var httpResponseMessage = await client.SendAsync(request);
            httpResponseMessage.EnsureSuccessStatusCode();
            var endResult = await httpResponseMessage.Content.ReadFromJsonAsync<DepartmentDTO>();
            if (endResult != null)
            {
                return RedirectToAction("Index", "DepartmentView");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> delete(DepartmentDTO department)
        {
            try {
            var client = httpClientFactory.CreateClient();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:7011/api/Department")
            };
                LoginModel LoginModel = new LoginModel
                {
                    userid = "writer@example.com",
                    password = "writer@123"
                };
                return1 token = await login(LoginModel);
                if (token != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);
                }

                request.Headers.Add("id", department.dept_id.ToString());
            var httpResponseMessage = await client.SendAsync(request);
            httpResponseMessage.EnsureSuccessStatusCode();
            var endResult = await httpResponseMessage.Content.ReadFromJsonAsync<DepartmentDTO>();
            if (endResult != null)
            {
                return RedirectToAction("Index", "DepartmentView");
            }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}

