﻿using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set;}
        public IProductRepository Product { get; private set;}

        public ICompanyRepository Company { get; private set; }

        public IApplicationUserRepositorty ApplicationUser {  get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public ApplicationDbContext _db;


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
