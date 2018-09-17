using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {


        void Save();
    }
}
