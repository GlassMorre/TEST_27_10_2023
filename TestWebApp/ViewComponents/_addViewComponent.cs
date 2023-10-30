using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TestWebApp.ViewComponents
{
    public class _addViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int a, int b)
        {
            string r;
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync(@"http://localhost:5055/add/1/2");
            }
            r = await response.Content.ReadAsStringAsync();
            return View("Default", r);
        }
    }
}