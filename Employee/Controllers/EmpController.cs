using Employee.Data;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Employee.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext newDB;

        public EmpController(ApplicationDbContext newDB)
        {
            this.newDB = newDB;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
         var employee = await newDB.Employees.ToListAsync();
            return View(employee);  
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmploye addEmployeRequest)
        {
            var employee = new employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeRequest.Name,
                age = addEmployeRequest.age,
                jobTitle = addEmployeRequest.jobTitle,
                start = addEmployeRequest.start,
                end = addEmployeRequest.end,
                companyName= addEmployeRequest.companyName,
                previousPosition = addEmployeRequest.previousPosition,
                pStart = addEmployeRequest.pStart,
                pEnd = addEmployeRequest.pEnd,
            };
            await newDB.Employees.AddAsync(employee);
            await newDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {

            var employee = await newDB.Employees.FirstOrDefaultAsync(x => x.Id == id);
           if(employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    age = employee.age,
                    jobTitle = employee.jobTitle,
                    start = employee.start,
                    end = employee.end,
                    companyName = employee.companyName,
                    previousPosition = employee.previousPosition,
                    pStart = employee.pStart,
                    pEnd = employee.pEnd,

                };
                return await Task.Run(()=>View("View",viewModel));

            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model) 
        {
            var employee = await newDB.Employees.FindAsync(model.Id);

            if (employee != null) 
            {

                employee.Id = model.Id;
                employee.Name=model.Name;
                employee.age = model.age;
                employee.jobTitle = model.jobTitle;
                employee.start = model.start;
                employee.end = model.end;
                employee.companyName = model.companyName;
                employee.previousPosition = model.previousPosition;
                employee.pStart = model.pStart;
                employee.pEnd = model.pEnd;

                await newDB.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");


        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model) 
        {
            var employee = await newDB.Employees.FindAsync(model.Id);
            if (employee != null) 
            {
                newDB.Employees.Remove(employee);
                await newDB.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
            

        }

    }


}
