using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Demo.Data;
using MVC_Demo.Models;

namespace MVC_Demo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()  //Role of Get function which gets the data from Db and then posts/displays it in the View - Index.cshtml
        {
            List<Category> catList = _db.Categories.ToList();
            return View(catList);
        }

        public IActionResult Create()  //Role of Post function which posts the data to the view - Create.cshtml.  We create the Create view by doing a right click  on Create and add a view
        {
            return View();              
        }
        [HttpPost]  //To post the data to Db
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()) //To test if the Display order and Name are same and generate an error in case of same
            {
                ModelState.AddModelError("Name", "Display Order and Name cannot be exactly same");

            }

            if (obj.Name == "test") //Will check if entered text in any of the fields is test and throws an error
            {
                ModelState.AddModelError("", "The Name cannot be test");

            }
            if (ModelState.IsValid)  //To check the Required tags like Max Length in Category.cs which is checked and also checks if the data input is given.
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Create"] = "Record Added to Database Successfully"; //TempData clears after navigating to next page
                return RedirectToAction("Index", "Category"); //Redirects to index of Category after submission of values and also in case of any issues after usign Modelstate and we get a error
            }

            return View();

        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            Category? categoryfromDB = _db.Categories.Find(id); //Below are multiple ways to do this task
            //Category? categoryfromDB1 = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            //Category? categoryfromDB2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            

            if (categoryfromDB == null)
            {
                return NotFound();
            }
            return View(categoryfromDB);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) //To test if the Display order and Name are same and generate an error in case of same
            {
                ModelState.AddModelError("Name", "Display Order and Name cannot be exactly same");

            }

            if (obj.Name == "test") //Will check if entered text in any of the fields is test and throws an error
            {
                ModelState.AddModelError("", "The Name cannot be test");

            }
            if (ModelState.IsValid)  //To check the Required tags like Max Length in Category.cs which is checked and also checks if the data input is given.
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Update"] = "Record Updated in Database Successfully";
                return RedirectToAction("Index", "Category"); //Redirects to index of Category after submission of values and also in case of any issues after usign Modelstate and we get a error
            }

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category? categoryfromDB1 = _db.Categories.Find(id);

            if (categoryfromDB1 == null)
            {
                return NotFound();
            }
            return View(categoryfromDB1);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id) //We are changing the DeletePOST to be Delete action with above annotation
        {
            Category? obj = _db.Categories.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }  
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Delete"] = "Record Removed from Database Successfully";
            return RedirectToAction("Index", "Category"); //Redirects to index of Category after submission of values and also in case of any issues after usign Modelstate and we get a error
            

           
        }
    }
}
