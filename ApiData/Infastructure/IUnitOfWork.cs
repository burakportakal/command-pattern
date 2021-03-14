using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Infastructure
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
