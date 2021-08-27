using System.ComponentModel.DataAnnotations;

namespace MetricsManager.Models
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}