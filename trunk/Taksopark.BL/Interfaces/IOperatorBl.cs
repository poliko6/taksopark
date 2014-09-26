﻿using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    public interface IOperatorBl
    {
        List<Request> GetAllRequests();
        void UpdateRequest(Request request);
        List<User> GetAllDrivers();
        Request GetRequestById(int id);
        List<Request> GetRequestsByState(int state);
        User GetUserById(int id);
        List<Request> GetAllRequestsByStatus(int status);
    }
}