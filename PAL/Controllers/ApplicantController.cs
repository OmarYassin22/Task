using AutoMapper;
using BL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAL.ViewModels;

namespace PAL.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;

        public ApplicantController(IApplicantRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }
        // GET: ApplicantController
        public async Task<IActionResult> Index()
        {

            var applicants = await _repository.GetAll();
            if (applicants.Count() > 0)
            {
                var result = _mapper.Map<IEnumerable<ApplicantDTO>>(applicants);
                return View(result);
            }
            return View();
        }

        // GET: ApplicantController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var applicant = await _repository.GetAsync(id);
            var result = _mapper.Map<ApplicantDTO>(applicant);
            return View(result);
        }



        // POST: ApplicantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicantDTO applicant)
        {
            if (ModelState.IsValid)
            {

                var app = _mapper.Map<Applicant>(applicant);
                var count = await _repository.AddAsync(app);
                if (count > 0)

                    TempData["Message"] = "Applicant Added Successfully";

                else
                    TempData["ErrorMessage"] = "Applicant Didn't Added";




            }
            else
            {
                TempData["ErrorMessage"] = "Model Is't Valid";

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ApplicantController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var applciant = await _repository.GetAsync(id);
            var result = _mapper.Map<ApplicantDTO>(applciant);
            return View(result);
        }

        // POST: ApplicantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicantDTO applicant)
        {
            if (ModelState.IsValid)
            {
                var app = _mapper.Map<Applicant>(applicant);
                var count = await _repository.UpdateAsync(app);
                if (count > 0)

                    TempData["Message"] = "Applicant Updated Successfully";

                else
                    TempData["ErrorMessage"] = "Applicant Didn't Updated";

            }
            else
            {
                TempData["ErrorMessage"] = "Model Is't Valid";

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> delete(int id)
        {
            try
            {

                var count = await _repository.DeleteAsync(id);

                if (count > 0)
                {
                    TempData["SuccessMessage"] = "Department deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error deleting department";
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    TempData["ErrorMessage"] = ex.Message;

                else
                    TempData["ErrorMessage"] = "Error deleting department";
                return RedirectToAction(nameof(Index));

            }
        }


        //    // POST: ApplicantController/Delete/5
        //    [HttpPost]
        //    //[ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Delete(int id)
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            var count = await _repository.DeleteAsunc(id);
        //            if (count > 0)
        //                TempData["Message"] = "Applicant Deleted Successfully";

        //            else
        //                TempData["ErrorMessage"] = "Applicant Didn't Deleted";
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
    }
}
