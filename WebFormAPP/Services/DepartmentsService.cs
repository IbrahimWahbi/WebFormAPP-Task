using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebFormAPP.Models;

namespace WebFormAPP.Services
{
    public interface IDepartmentsService
    {
        List<Departments> GetAllDepartments();
        Departments GetDepartmentById(int id);
    }
    public class DepartmentsService : IDepartmentsService
    {
        private readonly UnitOfWork unitOfWork;
        public DepartmentsService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public  List<Departments> GetAllDepartments()
        {
            return  unitOfWork.DepartmentRepository.GetAll().ToList();
           
        }

        public Departments GetDepartmentById(int id)
        {
            return unitOfWork.DepartmentRepository.GetByID(id);
        }
    }
}