﻿using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUserService
    {
        Task<User> GetUserByUserName(string userName);

    }
}
