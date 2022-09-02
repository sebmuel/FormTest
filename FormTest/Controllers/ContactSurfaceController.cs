using System.Web.Mvc;
using Umbraco.Web.Mvc;
using FormTest.Models;
using System.Net.Mail;


namespace FormTest.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";

        public ActionResult RenderForm()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            // ModelState.IsValid indicates if it was possible to bind the incoming
            // values from the request to the model correctly and whether any explicitly specified
            // validation rules were broken during the model binding process.
            if (ModelState.IsValid)
            {
                TempData["ContactSuccess"] = true;
                TempData["Model"] = model;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        public ActionResult SendEmail(ContactModel model)
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_ContactResult.cshtml", model);
        }
    }
}