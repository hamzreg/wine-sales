﻿using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataBaseContext _context;

        public SupplierRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Supplier Create(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();

                return GetByID(supplier.ID);
            }
            catch
            {
                throw new SupplierException("Failed to create supplier.");
            }
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetByID(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public Supplier GetByName(string name)
        {
            return _context.Suppliers.FirstOrDefault(supplier => supplier.Name == name);
        }

        public List<Supplier> GetByCountry(string country)
        {
            return _context.Suppliers.Where(supplier => supplier.Country == country)
                .ToList();
        }

        public List<Supplier> GetByLicense(bool license)
        {
            return _context.Suppliers.Where(supplier => supplier.License == license)
                .ToList();
        }

        public Supplier Update(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();

                return GetByID(supplier.ID);
            }
            catch
            {
                throw new SupplierException("Failed to update supplier.");
            }
        }

        public Supplier Delete(int id)
        {
            try
            {
                var foundSupplier = GetByID(id);

                if (foundSupplier == null)
                    return null;
                else
                {
                    _context.Suppliers.Remove(foundSupplier);
                    _context.SaveChanges();

                    return foundSupplier;
                }
            }
            catch
            {
                throw new SupplierException("Failed to delete supplier.");
            }
        }
    }
}
