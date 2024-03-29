﻿using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class UserBl : IUserBl
    {
        private readonly ISqlConnectionFactory _appConfigConnection;
        private readonly IOrderCostCalcStrategy _orderCostCalcStrategy;

        public UserBl(ISqlConnectionFactory appConfigConnection, IOrderCostCalcStrategy orderCostCalcStrategy)
        {
            _appConfigConnection = appConfigConnection;
            _orderCostCalcStrategy = orderCostCalcStrategy;
        }
        public int CreateRequest(Request request)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.Create(request);
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.RequestRepository.Update(request);
            }
        }

        public void CreateComment(Comment comment)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.CommentRepository.Create(comment);
            }
        }

        public void CreateUser(User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Create(user);
            }
        }

        public List<Car> GetAllCars()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.CarRepository.GetAllCars().ToList();
            }
        }

        public List<Request> GetAllRequestsByCreatorID(int creatorId)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequestsByCreatorId(creatorId).ToList();
            }
        }

        public bool IsLoginBooked(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.IsLoginBooked(login);
            }
        }


        public User GetUserByLoginAndPassword(string login, string password)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.GetUserByLogInAndPassword(login, password);
            }
        }


        public User GetUserByLogin(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.GetUserByLogIn(login);
            }
        }

        public Request GetRequestById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetRequestById(id);
            }
        }


        public void UpdateUser(User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Update(user);
            }
        }


        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }

        public decimal GetEstimatedCost(decimal distance, bool isTracking, decimal? animalWeight, bool isHaulage)
        {
            return this._orderCostCalcStrategy.CalcCost(distance, isTracking, animalWeight, isHaulage);
        }


        public List<Comment> GetAllCommentsByRequestId(int requestId)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.CommentRepository.GetAllCommentsByRequestId(requestId).ToList();
            }
        }
    }
}
