using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PresentationLayer.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {
        private readonly  IDepartmentRepository _departmemtRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            //_departmemtRepository = new DepartmemtRepository()
            _departmemtRepository = unitOfWork.DepartmentRepository;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index(string SearchValue)
        {
            dynamic departments = Enumerable.Empty<Department>();
            if (string.IsNullOrEmpty(SearchValue))
                departments = await _departmemtRepository.GetAll();
            else
                departments = _departmemtRepository.GetDepartmentByName(SearchValue);


            var mappedDepartments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);
            return View(mappedDepartments);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DepartmentViewModel departmentVM)
        {
            if(ModelState.IsValid)
            {
                var mappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                await _departmemtRepository.Add(mappedDepartment);
                TempData["Message"] = "Department is Created Seccessfully";
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
        }

        public async Task<IActionResult> Datails(int? id,string ViewName= "Datails")
        {
            if (id == null)
             return NotFound();


            var department = await _departmemtRepository.Get(id.Value);
            if (department == null)
                return NotFound();

            var mappedDepartment = _mapper.Map<Department,DepartmentViewModel>(department);

           
            
            return View(ViewName, mappedDepartment);
        } 



        public async Task<IActionResult> Edit(int? id)
        {

            return await Datails(id,"Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( DepartmentViewModel departmentVM, [FromRoute] int? ID)
        {
            if(ID.Value  !=departmentVM.Id)
                return BadRequest();

           if(ModelState.IsValid)
            {
                try
                {
                    var mappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                    await _departmemtRepository.Update(mappedDepartment);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception)
                {
                    //log in database
                    //friendly message
                    //ModelState.AddModelError("",ex.Message);
                    return View(departmentVM);
                    
                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Datails(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id,DepartmentViewModel departmentVM) 
        {
            if(id.Value!=departmentVM.Id)
                return BadRequest();

            try
            {
                var mappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                await _departmemtRepository.Delete(mappedDepartment);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View(departmentVM);
            }
           
        }
    }
}
