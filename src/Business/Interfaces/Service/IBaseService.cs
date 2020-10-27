using Business.Models;
using System;

namespace Business.Interfaces.Service
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : EntityBase
    {
    }
}
