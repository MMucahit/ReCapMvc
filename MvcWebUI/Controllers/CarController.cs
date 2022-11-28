﻿using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class CarController : Controller
    {
        //InMemoryCarDal _cars = new InMemoryCarDal();
        EfCarDal _cars = new EfCarDal();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            List<Car> cars = _cars.GetAll();
            return View("GetAll", cars);
        }

        public IActionResult GetById(Car car)
        {
            Car _car = _cars.GetById(car);
            return View("GetById", _car);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Added");
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Car _car = _cars.GetById(id);
            return View("Update", _car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            _cars.Update(car);
            Console.WriteLine("Updated");
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public IActionResult Delete(Car car)
        {
            _cars.Delete(car);
            Console.WriteLine("Deleted");
            return RedirectToAction("GetAll");
        }
    }
}