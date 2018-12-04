using GigHub.Models;
using GigHub.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{ public class GigsController : Controller

    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        //Purpose of that parameter is because that's the model behind the view 
        //So, when we post the form , that's what we're going to get in the create action
        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //We need to convert that viewModel to GigObject,
            //added to our context and save changes

            //string artist = User.Identity.GetUserId();
            //ApplicationUser currentArtist = _context.Users.FirstOrDefault(x => x.Id == artist);
            //var currentArtist = _context.Users.Single(u => u.Id == User.Identity.GetUserId());
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }


            var gig = new Gig
            {
                //Artist = currentArtist,
                ArtistId = User.Identity.GetUserId(),
            //the values that user put into the date & time field are valid,
            // We can combine them using daytime parse
            DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue

            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}