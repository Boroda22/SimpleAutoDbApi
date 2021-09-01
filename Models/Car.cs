namespace SimpleAutoDbApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        /// <summary>
        /// Макрка автомобиля
        /// </summary>
        public CarBrand Brand { get; set; }

        /// <summary>
        /// Модель автомобиля
        /// </summary>
        public CarModel Model { get; set; }

        /// <summary>
        /// Модификация автомобиля
        /// </summary>
        public CarModification Modification { get; set; }

        /// <summary>
        /// Поколение автомобиля
        /// </summary>
        public int Generation { get; set; }
    }
}
