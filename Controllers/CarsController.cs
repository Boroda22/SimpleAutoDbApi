using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleAutoDbApi.Models;
using SimpleAutoDbApi.Services;

namespace SimpleAutoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /// <summary>
        /// Список автомобилей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            return AutoDbService.GetCars();
        }

        /// <summary>
        /// Получение автомобиля по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор автомобиля</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = AutoDbService.GetCarById(id);

            if(car == null)
            {
                return NotFound();
            }

            return car;
        }

        /// <summary>
        /// Обновление данных автомобиля
        /// </summary>
        /// <param name="id"> Идентификатор автомобиля</param>
        /// <param name="car"> Объект автомобиля</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Car> PutCar(int id, Car car)
        {
            if(id != car.Id)
            {
                return BadRequest();
            }

            var updatedCar = AutoDbService.UpdateCar(id, car);
            if(updatedCar == null)
            {
                return NotFound();
            }

            return updatedCar;
        }

        // Добавление нового автомобиля
        [HttpPost]
        public ActionResult<Car> PostCar(Car car)
        {
            AutoDbService.AddCar(car);

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        /// <summary>
        /// Удаление автомобиля
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            AutoDbService.DeleteCar(id);

            return CreatedAtAction("GetCars", null);
        }

        /// <summary>
        /// Поиск по модификации
        /// </summary>
        /// <param name="modif"> Модификация</param>
        /// <returns></returns>
        [HttpGet("GetCarByMod/{modification}")]
        public ActionResult<IEnumerable<Car>> GetCarByMod(string modification)
        {
            var result = AutoDbService.GetCarByModification(modification);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
