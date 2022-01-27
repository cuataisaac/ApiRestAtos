using ApiRestAtosDataAccess.Data.Repository;
using ApiRestAtosModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiRestAtos.Area.Admin.Controllers
{

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IWorkContainer workContainer;

        public UsersController(IWorkContainer workContainer)
        {
            this.workContainer = workContainer;
        }

        public IWorkContainer GetWorkContainer()
        {
            return workContainer;
        }

        [HttpGet]
        [Route("/Users/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = workContainer.User.GetAll() });
        }

        [HttpGet]
        [Route("/Users/GetOne")]
        public async Task<IActionResult> GetOne(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = workContainer.User.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(new { Data = user });
        }

        [HttpPost]
        [Route("/Users/Create")]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                workContainer.User.Add(user);
                workContainer.Save();
                return Json(new { data = workContainer.User.Get(user.IdUser) });
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("/Users/Update")]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                workContainer.User.Uptate(user);
                workContainer.Save();
                return Json(new { data = workContainer.User.Get(user.IdUser) });
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("/Users/Delete")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = workContainer.User.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            workContainer.User.Remove(user);
            workContainer.Save();
            return Json(new { Data = workContainer.User.GetAll() });
        }

    }
}
