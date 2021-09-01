using SimpleAutoDbApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAutoDbApi.Services
{
    /// <summary>
    /// Служба заменяет базу данных
    /// </summary>
    public static class AutoDbService
    {
        private static List<Car> Cars { get; }

        static AutoDbService()
        {
            // заполнение первоначальными данными
            Cars = new List<Car>
            {
                new Car
                    { Id = 1,
                    Brand = new CarBrand{Id = 1, Name = "Volvo"},
                    Model = new CarModel{Id = 1, Name = "X60"},
                    Modification = new CarModification{Id = 1, Name = "Модификация 1"},
                    Generation = 2},
                new Car
                    { Id = 2,
                    Brand = new CarBrand{Id = 1, Name = "Volvo"},
                    Model = new CarModel{Id = 2, Name = "X60"},
                    Modification = new CarModification{Id = 2, Name = "Модификация 2"},
                    Generation = 1},
                new Car
                    { Id = 3,
                    Brand = new CarBrand{Id = 2, Name = "ВАЗ"},
                    Model = new CarModel{Id = 3, Name = "X60"},
                    Modification = new CarModification{Id = 3, Name = "Модификация 3"},
                    Generation = 3},
                new Car
                    { Id = 4,
                    Brand = new CarBrand{Id = 2, Name = "ВАЗ"},
                    Model = new CarModel{Id = 4, Name = "X60"},
                    Modification = new CarModification{Id = 2, Name = "Модификация 2"},
                    Generation = 1},
                new Car
                    { Id = 5,
                    Brand = new CarBrand{Id = 3, Name = "ТАЗ"},
                    Model = new CarModel{Id = 5, Name = "X60"},
                    Modification = new CarModification{Id = 1, Name = "Модификация 1"},
                    Generation =3},
            };
        }

        /// <summary>
        /// Возвращает список всех автомобилей в базе
        /// </summary>
        /// <returns></returns>
        public static List<Car> GetCars()
        {
            return Cars;
        }
        
        /// <summary>
        /// Поиск автомобиля по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Car GetCarById(int id)
        {
            return Cars.Where(k => k.Id == id).FirstOrDefault();
        }
        
        /// <summary>
        /// Метод обновления данных объекта
        /// </summary>
        /// <param name="id"> идентификатор объекта</param>
        /// <param name="car"> объект обновления</param>
        /// <returns></returns>
        public static Car UpdateCar(int id, Car car)
        {
            var tmpCar = Cars.Where(b => b.Id == id).FirstOrDefault();

            if(tmpCar != null)
            {
                tmpCar.Brand = car.Brand;
                tmpCar.Model = car.Model;
                tmpCar.Modification = car.Modification;
            }

            return tmpCar == null ? null : tmpCar;
        }
        
        /// <summary>
        /// Метод добавления объекта
        /// </summary>
        /// <param name="car"></param>
        public static void AddCar(Car car)
        {
            Cars.Add(car);
        }

        /// <summary>
        /// Метод удаления объекта
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteCar(int id)
        {
            var car = Cars.Where(b => b.Id == id).FirstOrDefault();
            if(car != null)
            {
                Cars.Remove(car);
            }
        }

        /// <summary>
        /// Поиск автомобиля по его модификации
        /// </summary>
        public static List<Car> GetCarByModification(string modification)
        {
            return Cars.Where(d => d.Modification.Name == modification).ToList();
        }
    }
}
