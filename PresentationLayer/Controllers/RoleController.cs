using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index(string SearchValue)
        {
            var roles = Enumerable.Empty<IdentityRole>().ToList();
            if (string.IsNullOrEmpty(SearchValue))
                roles.AddRange(_roleManager.Roles);
            else
                roles.Add(await _roleManager.FindByNameAsync(SearchValue));



            return View(roles);

        }

        public IActionResult Create()
        {
            //ViewBag.Departments=_departmemtRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(Role);

                return RedirectToAction(nameof(Index));
            }
            return View(Role);
        }

        public async Task<IActionResult> Datails(string id, string ViewName = "Datails")
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(ViewName, role);
        }



        public async Task<IActionResult> Edit(string id)
        {
            //ViewBag.Departments = _departmemtRepository.GetAll();
            return await Datails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole UpdatedRole, [FromRoute] string Id)
        {
            if (Id != UpdatedRole.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(Id);
                    role.Name = UpdatedRole.Name;


                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception)
                {
                    //log in database
                    //friendly message
                    //ModelState.AddModelError("",ex.Message);
                    return View(UpdatedRole);

                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Datails(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string Id, IdentityRole DeletedRole)
        {
            if (Id != DeletedRole.Id)
                return BadRequest();

            try
            {
                var role = await _roleManager.FindByIdAsync(Id);
                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View(DeletedRole);
            }

        }
    }
}
