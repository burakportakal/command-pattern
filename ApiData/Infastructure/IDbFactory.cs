using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Infastructure
{
    public interface IDbFactory<TContext> : IDisposable where TContext : class
    {
        TContext Init();
    }
}
