﻿using LibServer.Repository;
using System;

namespace LibServer.DataBase
{
    /// <summary>
    /// 實作Unit Of Work的interface。
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        void Commit();

        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>
        IRepository<T> Repository<T>() where T : class;
    }
}
