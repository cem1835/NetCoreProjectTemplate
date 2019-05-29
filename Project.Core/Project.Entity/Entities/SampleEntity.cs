using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    // Sample Entity
    public class SampleEntity:BaseEntity<int>,IEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
