﻿using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DtoLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
    }
}
 