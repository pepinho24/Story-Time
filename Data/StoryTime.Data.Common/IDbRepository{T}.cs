﻿namespace StoryTime.Data.Common
{
    using System.Linq;

    using StoryTime.Data.Common.Models;

    public interface IDbRepository<T>
       where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();

        void Dispose();
    }
    //public interface IDbRepository<T> : IDbRepository<T, int>
    //    where T : BaseModel<int>
    //{
    //}

    //public interface IDbRepository<T, in TKey>
    //    where T : BaseModel<TKey>
    //{
    //    IQueryable<T> All();

    //    IQueryable<T> AllWithDeleted();

    //    T GetById(TKey id);

    //    void Add(T entity);

    //    void Delete(T entity);

    //    void HardDelete(T entity);

    //    void Save();
    //}
}
