﻿using _2rpnet.rpa.webAPI.Domains;
using System.Collections.Generic;

namespace _2rpnet.rpa.webAPI.Interfaces
{
    public interface IUserTypeRepository
    {
        IEnumerable<UserType> ReadAll();
        UserType SearchByID(int id);
    }
}
