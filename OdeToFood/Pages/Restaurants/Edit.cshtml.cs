using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int RestaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetById(RestaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Restaurant = restaurantData.Update(Restaurant);
            restaurantData.Commit();
            return Page();
        }
    }
}