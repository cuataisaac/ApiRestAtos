using ApiRestAtosDataAccess.Data.Repository;
using ApiRestAtosModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiRestAtos.Area.Admin.Controllers
{

    [Area("Admin")]
    public class ProfilesController : Controller
    {
        private readonly IWorkContainer workContainer;

        public ProfilesController(IWorkContainer workContainer)
        {
            this.workContainer = workContainer;
        }


        public IWorkContainer GetWorkContainer()
        {
            return workContainer;
        }

        [HttpGet]
        [Route("/Profiles/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = GetWorkContainer().Profile.GetAll();
            return Ok(new { data = data, count = data.Count() });
        }

        [HttpGet]
        [Route("/Profiles/GetOne")]
        public async Task<IActionResult> GetOne(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile = workContainer.Profile.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        [Route("/Profiles/Create")]
        public async Task<IActionResult> Create([Bind("Id,ProfileName")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                workContainer.Profile.Add(profile);
                workContainer.Save();
                return Json(new { data = workContainer.Profile.Get(profile.Id) });
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("/Profiles/Update")]
        public IActionResult Update([Bind("Id,ProfileName")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                workContainer.Profile.Uptate(profile);
                workContainer.Save();
                return Json(new { data = workContainer.Profile.Get(profile.Id) });
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("/Profiles/Delete")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile = workContainer.Profile.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            workContainer.Profile.Remove(profile);
            workContainer.Save();
            return Json(new { Data = workContainer.Profile.GetAll() });
        }

    }
}
