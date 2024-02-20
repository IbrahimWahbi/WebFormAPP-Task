using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormAPP.Models
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Departments> departmentRepository;
        private GenericRepository<Employees> employeesRepository;
        private GenericRepository<DepartmentsEmployess> departmentsEmployess;
        public GenericRepository<Departments> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Departments>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Employees> EmployeeRepository
        {
            get
            {

                if (this.employeesRepository == null)
                {
                    this.employeesRepository = new GenericRepository<Employees>(context);
                }
                return employeesRepository;
            }
        }
        public GenericRepository<DepartmentsEmployess> DepartmentsEmployessRepository
        {
            get
            {

                if (this.departmentsEmployess == null)
                {
                    this.departmentsEmployess = new GenericRepository<DepartmentsEmployess>(context);
                }
                return departmentsEmployess;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}