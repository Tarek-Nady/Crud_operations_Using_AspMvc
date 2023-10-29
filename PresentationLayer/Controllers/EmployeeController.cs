using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Helpers;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmemtRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_employeeRepository = new employeeRepository()
            _employeeRepository = unitOfWork.EmployeeRepository;
            _departmemtRepository = unitOfWork.DepartmentRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            var employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(SearchValue))
                employees =await _employeeRepository.GetAll();
            else
                employees = _employeeRepository.GetEmployeesByName(SearchValue);


            var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedEmps);

        }

        public IActionResult Create()
        {
            //ViewBag.Departments=_departmemtRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                if (employeeVM.Image != null)
                    employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "images");

                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                await _employeeRepository.Add(mappedEmp);
                TempData["Message"] = "Employee is Created Seccessfully";

                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        public async Task<IActionResult> Datails(int? id, string ViewName = "Datails")
        {
            if (id == null)
                return NotFound();


            var employee = await _employeeRepository.Get(id.Value);

            if (employee == null)
                return NotFound();
            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            TempData["ImageName"] = mappedEmp.ImageName;
             
            return View(ViewName, mappedEmp);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            //ViewBag.Departments = _departmemtRepository.GetAll();
            return await Datails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeVM, [FromRoute] int? ID)
        {
            if (ID.Value != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    if (employeeVM.Image != null)
                        employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "images");

                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                   await _employeeRepository.Update(mappedEmp);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception)
                {
                    //log in database
                    //friendly message
                    //ModelState.AddModelError("",ex.Message);
                    return View(employeeVM);

                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Datails(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            if (id.Value != employeeVM.Id)
                return BadRequest();

            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                int count = await _employeeRepository.Delete(mappedEmp);

                if (count > 0 && employeeVM.ImageName != null)
                   DocumentSettings.DeleteFile(employeeVM.ImageName, "images");


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View(employeeVM);
            }

        }
    }
}
