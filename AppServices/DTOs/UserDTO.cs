﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int IdUserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserTypeDTO UserType { get; set; }


    }
}
