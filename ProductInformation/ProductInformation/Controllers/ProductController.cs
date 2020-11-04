using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using ProductInformation.Models;

namespace ProductInformation.Controllers
{
    public class ProductController : Controller
    {
        

        // Actions
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult Create(string categoryID, string name)
        {
            if (Request.Method == "POST")
                {
                    try
                    {
                        CreateProduct(categoryID, name);
                    ViewBag.Message = $"Successfully Created Product {name}"!;
                    }
                    catch (Exception e)
                    {
                        ViewBag.CategoryID = 
                        ViewBag.Message = "Error: " + e.Message;
                        ViewBag.Error = true;
                    }
                }

            return View();
        }
        public IActionResult List()
        {
            ViewBag.Products = GetProducts();
            return View();
        }

      

        // Data Methods
        public List<Product> GetProducts()
        {
            List<Product> results;
            using (ProductInfoContext context = new ProductInfoContext())
            {
                results = context.Products.Include(x => x.Category).ToList();
            }
            return results;
        }

        public void CreateProduct(string categoryID, string name)
        {
            int parsedCategoryID;

            // Trimming category id
            categoryID = categoryID != null ? categoryID.Trim() : null;
            name = name != null ? name.Trim() : null;

            // Check for individual validation cases and throw an exception if they fail - more details tomorrow

            if (string.IsNullOrWhiteSpace(categoryID))
            {
                throw new Exception("Category ID not provided!");
            }
            if (!int.TryParse(categoryID, out parsedCategoryID))
            {
                throw new Exception("Category ID fails Parse!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name not provided!");
            }

            using (ProductInfoContext context = new ProductInfoContext())
            {
                if (context.Categories.Where(x => x.ID == parsedCategoryID).Count() < 1)
                    {
                    throw new Exception("Category does not exist!");
                    }

                context.Products.Add(new Product()
                {
                    CategoryID = int.Parse(categoryID),
                    Name = name
                });
                context.SaveChanges();
            }
        }
    }
}
