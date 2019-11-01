﻿using System.Collections.Generic;

namespace FluentValidationProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<string> AddressLines { get; set; } = new List<string>();

    }
}
