using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;


namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToPage();
        }

        public Pizza NewPizza { get; set; } = default!;

        public IActionResult OnPost(Pizza newPizza)
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                PizzaList = _service.GetPizzas();
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToPage();
        }
    }
}
