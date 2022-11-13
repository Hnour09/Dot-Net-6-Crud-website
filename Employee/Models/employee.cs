using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class employee
    {
        [Key]
        public Guid Id { get; set; }        
        public string Name { get; set; }
        
    
        public int age { get; set; }

        public string jobTitle { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        
        public string previousPosition { get; set; }

        public string companyName { get; set; }

        public DateTime pStart { get; set; }
        public DateTime pEnd { get; set; }

    }
}
