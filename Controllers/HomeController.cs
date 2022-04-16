using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using gruppuppgiftHemnet.Models;
using gruppuppgiftHemnet.Models.DTO;
using Newtonsoft.Json;



namespace gruppuppgiftHemnet.Controllers
{
    public class HomeController : Controller
    {
        readonly string BaseURL = "https://realtyfirmapi2.azurewebsites.net/api/";

        List<Listing> ListingInfo = new List<Listing>();


        [HandleError]
        public async Task<ActionResult> Index(string sortOption)
        {


            ViewBag.AdressSortOrder = String.IsNullOrEmpty(sortOption) ? "alph_desc" : "";
            ViewBag.PriceSortOrder = sortOption == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.RoomSortOrder = sortOption == "room_asc" ? "room_desc" : "room_asc";
            ViewBag.AreaSortOrder = sortOption == "area_asc" ? "area_desc" : "area_asc";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("listings");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ListingInfo = JsonConvert.DeserializeObject<List<Listing>>(EmpResponse);
                } else
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

                };


            }


            switch (sortOption)
            {
                case "alph_desc":
                    ListingInfo = ListingInfo.OrderByDescending(s => s.Address).ToList();
                    break;
                case "price_asc":
                    ListingInfo = ListingInfo.OrderBy(s => s.Listing_Price).ToList();
                    break;
                case "price_desc":
                    ListingInfo = ListingInfo.OrderByDescending(s => s.Listing_Price).ToList();
                    break;
                case "room_asc":
                    ListingInfo = ListingInfo.OrderBy(s => s.Room_Count).ToList();
                    break;
                case "room_desc":
                    ListingInfo = ListingInfo.OrderByDescending(s => s.Room_Count).ToList();
                    break;
                case "area_asc":
                    ListingInfo = ListingInfo.OrderBy(s => s.Floor_Area).ToList();
                    break;
                case "area_desc":
                    ListingInfo = ListingInfo.OrderByDescending(s => s.Floor_Area).ToList();
                    break;
                default:
                    ListingInfo = ListingInfo.OrderBy(s => s.Address).ToList();
                    break;
            }




            return View(ListingInfo);
        }



        [HandleError]
        public async Task<ActionResult> Details(Guid id)
        {
            var detailsListing = new Listing();




            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"listings/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    detailsListing = JsonConvert.DeserializeObject<Listing>(EmpResponse);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    
                }


                return View(detailsListing);

            }

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(string email, string firstName, string lastname, string phone, string listId)
        {

            var intresseAnm = new SubscriptionDTO(){ Email = email, FirstName = firstName, LastName = lastname, PhoneNumber = phone, Listing_Id = listId };


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://realtyfirmapi2.azurewebsites.net/api/listings/subscribe");
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsync(client.BaseAddress, new StringContent(
                new JavaScriptSerializer().Serialize(intresseAnm), Encoding.UTF8, "application/json"));

                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Details");

            }

            ModelState.AddModelError(string.Empty, "An error occured when procssing. Please contact site owner for assistance.");
            return RedirectToAction("Details");
        }



    }
}