using System.ComponentModel.DataAnnotations;

namespace WebApiCrud.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
