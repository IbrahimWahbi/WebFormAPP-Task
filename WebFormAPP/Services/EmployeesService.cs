using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebFormAPP.Dtos;
using WebFormAPP.Models;

namespace WebFormAPP.Services
{
    public interface IEmployeesService
    {
        List<Employees> GetAllEmployeess();
        bool AddEmployee(Employees model, List<DepartmentsEmployess> departmentsEmployesses);

        bool EditEmployee(EmployeesDto dto);
        bool Delete_Employee(long EmployeeId);
    }
    public class EmployeesService : IEmployeesService
    {
        private readonly UnitOfWork unitOfWork;
        public EmployeesService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public bool AddEmployee(Employees model, List<DepartmentsEmployess> departmentsEmployesses)
        {
            unitOfWork.EmployeeRepository.Insert(model);
            //unitOfWork.DepartmentsEmployessRepository.Insert(model.DepartmentsEmployess.FirstOrDefault());
            //try
            //{
            //    unitOfWork.Save();
            //}
            //catch(Exception e)
            //{ 
            //}
            //foreach(var x in departmentsEmployesses)
            //{
            //    x.Employees = model;
            //    unitOfWork.DepartmentsEmployessRepository.Insert(x);
            //}
            try
            {
                unitOfWork.Save();
            }
            catch (Exception e)
            {
            }

            return true;
        }

        public  List<Employees> GetAllEmployeess()
        {
           return  unitOfWork.EmployeeRepository.GetAll().ToList();
            
        }

        public bool EditEmployee(EmployeesDto dto)
        {
            var Employee_s = unitOfWork.EmployeeRepository.Get(m => m.EmployeeID == dto.EmployeeID);

            if(Employee_s.Any())
            {
                var Employee_ = Employee_s.FirstOrDefault();
                Employee_.Position = dto.Position;
                Employee_.Salary = dto.Salary;
                Employee_.DateOfBirth = dto.DateOfBirth;
                Employee_.FirstName = dto.FirstName;
                Employee_.LastName = dto.LastName;
                Employee_.DepartmentsEmployess = new List<DepartmentsEmployess>();
                foreach (var single_depart in dto.DepartmentsEmployess)
                {
                    Employee_.DepartmentsEmployess.Add(new DepartmentsEmployess()
                    {
                        DepartmentID = single_depart.DepartmentID
                    });
                }

                unitOfWork.EmployeeRepository.Update(Employee_);
                unitOfWork.Save();

            }
            else
            {
                return false;
            }

            return true;
        }

        public EmployeesDto Get_Employee_ById(long EmployeeId)
        {
            var _Employee_s = unitOfWork.EmployeeRepository.Get(m => m.EmployeeID == EmployeeId);

            EmployeesDto res=new EmployeesDto();

            if (_Employee_s .Any())
            {
                var _Employee_ = _Employee_s.FirstOrDefault();

                res.DateOfBirth = _Employee_.DateOfBirth;
                res.FirstName = _Employee_.FirstName;
                res.LastName = _Employee_.LastName;
                res.Salary = _Employee_.Salary;
                res.EmployeeID = EmployeeId;
                res.Position = _Employee_.Position;
                res.DepartmentsEmployess = new List<DepartmentsEmployessDto>();

                foreach(var single_em in _Employee_.DepartmentsEmployess)
                {
                    res.DepartmentsEmployess.Add(new DepartmentsEmployessDto()
                    {
                        DepartmentID=single_em.DepartmentID,
                        EmployeeID=single_em.EmployeeID,
                        DepartmentsEmployessID=single_em.DepartmentID,
                        DepartmentName = single_em.Departments.DepartmentName
                    });
                }
            }

            return res;

        }


        public bool Delete_Employee(long EmployeeId)
        {
            var _Employee_s = unitOfWork.EmployeeRepository.Get(m => m.EmployeeID == EmployeeId);


            if (_Employee_s.Any())
            {
                var Employee_ = _Employee_s.FirstOrDefault();
                unitOfWork.EmployeeRepository.Delete(Employee_);
                unitOfWork.Save();

                return true;
            }
            else
                return false;
        }
    }
}