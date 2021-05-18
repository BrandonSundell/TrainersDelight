using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainersDelight.Data;
using TrainersDelight.Models;

namespace TrainersDelight.Controllers
{
    public class MyClientsController : Controller
    {
        private readonly TrainersDelightContext _context;

        public MyClientsController(TrainersDelightContext context)
        {
            _context = context;
        }

        // GET: MyClientsController
        public ActionResult Index()
        {
            var currentUser = User.Identity.Name;
            var clients = _context.Clients.Where(c => c.TrainerId.Equals(User.Identity.Name));
            ViewBag.ClientList = _context.Clients.Where(c => c.TrainerId.Equals(User.Identity.Name));
            return View();
        }

        public async Task<IActionResult> ClientProfile(int id)
        {
           
            var currentClient = _context.Clients.Where(c => c.ClientId.Equals(id)).Single();
            var ClientBMI = _context.ClientBMIs;
            var ClientBFP = _context.ClientBFPs;
            var ClientWeight = _context.ClientWeights;
            var ClientGoals = _context.ClientGoals;

            //BMI 
            if (ClientBMI.Find(id) == null)
            {
                await _context.ClientBMIs.AddAsync(new ClientBMI() { ClientId = id, BMI = 0, DateOfMessurment = DateTime.Now });
                await _context.SaveChangesAsync();
            }
          
            var bmi = _context.ClientBMIs.Where(c => c.ClientId.Equals(id)).Single();
            ViewBag.clientBMI = bmi;

            //BFP
            if (ClientBFP.Find(id) == null)
            {
                await _context.ClientBFPs.AddAsync(new ClientBFP() { ClientId = id, BFP = 0, DateOfMessurment = DateTime.Now });
                await _context.SaveChangesAsync();
            }

            var bfp = _context.ClientBFPs.Where(c => c.ClientId.Equals(id)).Single();
            ViewBag.clientBFP = bfp;

            //Weight
            if (ClientWeight.Find(id) == null)
            {
                await _context.ClientWeights.AddAsync(new ClientWeight() { ClientId = id, WeightInPounds = 0, DateOfMessurment = DateTime.Now });
                await _context.SaveChangesAsync();
            }

            var weight = _context.ClientWeights.Where(c => c.ClientId.Equals(id)).Single();
            ViewBag.clientWeight = weight;

            //Goals
            if (ClientGoals.Find(id) == null)
            {
                await _context.ClientGoals.AddAsync(new ClientGoals() { ClientId = id, Goals = "Enter your clients goals", DateOfMessurment = DateTime.Now });
                await _context.SaveChangesAsync();
            }

            var goals = _context.ClientGoals.Where(c => c.ClientId.Equals(id)).Single();
            ViewBag.clientGoals = goals;

            //ViewBag.clientBFP = _context.ClientBFPs.Where(c => c.ClientId.Equals(id)).Single();
            //ViewBag.clientWeight = _context.ClientWeights.Where(c => c.ClientId.Equals(id)).Single();
            //ViewBag.clientGoals = _context.ClientGoals.Where(c => c.ClientId.Equals(id)).Single();
            
            return View(currentClient);
        }
    }
}
