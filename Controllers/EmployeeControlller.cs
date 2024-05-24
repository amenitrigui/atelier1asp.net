using atelier1.Models.Repository;
using atelier1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace atelier1.Controllers
{
    public class EmployeeControlller : Controller
    {
        readonly Irepository<Employe> employeeRepository;
        public EmployeeControlller(Irepository<Employe> empRepository)
        {
            employeeRepository = empRepository;
        }



        public ActionResult Search(string term)
        {
            var result = employeeRepository.Search(term);
            return View("Index", result);
        }

        public ActionResult Edit(int id)
        {
            Employe employee = employeeRepository.FindByID(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employe editedEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    employeeRepository.Update(id, editedEmployee);

                    return RedirectToAction(nameof(Index));
                }

                return View(editedEmployee);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {

            Employe employee = employeeRepository.FindByID(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employe e)
        {
            try
            {

                employeeRepository.Delete(e.Id);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Index()
        {
            var employees = employeeRepository.GetAll();
         
            ViewData["EmployeesCount"] = employees.Count;
            ViewData["SalaryAverage"] = employeeRepository.SalaryAverage();
            ViewData["MaxSalary"] = employeeRepository.MaxSalary();
            ViewData["HREmployeesCount"] = employeeRepository.HrEmployeesCount();
            return View(employees);

        }
        public ActionResult Details(int id)
        {
            return View(employeeRepository.FindByID(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employe model)
        {
            if (ModelState.IsValid)
            {

                Employe newProduct = new Employe
                {
                    Id = model.Id,
                    Name = model.Name,
                    Departement = model.Departement,
                    Sallery = model.Sallery,
                  
                   
                };
                employeeRepository.Add(newProduct);
                return RedirectToAction("Details", new { id = newProduct.Id });
            }
            return View();
        }





















        //[HttpPost]
        //public ActionResult Create(Employe e)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Ajouter l'employé à la base de données via le repository
        //        employeeRepository.Add(e);
        //        // Rediriger vers une autre action (par exemple, vers une page de confirmation)
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    // En cas d'erreur de validation, retourner à la vue Create avec les erreurs
        //    return View();
        //}
        //public ActionResult Delete()
        //{
        //    return View(employeeRepository.Delete( id));
           
        //}

        //public ActionResult Update()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Update(Employe e)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Ajouter l'employé à la base de données via le repository
        //        employeeRepository.Update(1,e); 
        //        // Rediriger vers une autre action (par exemple, vers une page de confirmation)
        //        return RedirectToAction("Index", "Employee");
        //    }
        //    // En cas d'erreur de validation, retourner à la vue Create avec les erreurs
        //    return View(e);
        //}


    }
}
