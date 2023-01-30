using System.ComponentModel.DataAnnotations;

namespace DBWebApp.DAL
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }

        public Animal(int idAnimal, string name, string description, string category, string area)
        {
            IdAnimal = idAnimal;
            Name = name;
            Description = description;
            Category = category;
            Area = area;
        }

        public Animal() { }
    }
}
