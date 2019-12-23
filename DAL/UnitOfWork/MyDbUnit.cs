using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using LibServer.DataBase;

namespace DAL.UnitOfWork
{
    public interface IMyDbUnit : IUnitOfWork { }

    public class MyDbUnit : ACUnitOfWork<MyDbContext>, IMyDbUnit
    {
        public MyDbUnit(MyDbContext context) : base(context)
        {
        }
    }
}
