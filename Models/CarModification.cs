namespace SimpleAutoDbApi.Models
{
    /// <summary>
    /// Модификация автомобиля
    /// </summary>
    public class CarModification
    {
        public int Id { get; set; }
        /// <summary>
        /// Название модификации
        /// </summary>
        public string Name { get; set; }
    }
}
