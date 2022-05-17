using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private IDepreciationDbContext depreciationDbContext;

        public EFEmployeeRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Employee t)
        {
            try
            {
                ValidateEmployee(t);
                depreciationDbContext.Employees.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public bool Delete(Employee t)
        {
            try
            {
                if (t == null)
                {
                    throw new NotImplementedException("El objeto asset no puede ser null");
                }
               Employee employee = FindByDni(t.Dni);

                if (employee == null)
                {
                    throw new NotImplementedException($"El objeto con ID {t.Id} no existe");
                }

                depreciationDbContext.Employees.Remove(employee);
                int result = depreciationDbContext.SaveChanges();
                return result > 0;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee FindByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public Employee FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindByLastnames(string lastnames)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lastnames))
                {

                    throw new NotImplementedException($"El parametro name ´{lastnames}´ no tiene el formato correcto ");
                }
                return depreciationDbContext.Employees.Where(x => x.Lastnames.Equals(lastnames, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SetAssetsToEmployee(Employee employee, List<Asset> assets)
        {
            throw new NotImplementedException();
        }

        public bool SetAssetToEmployee(Employee employee, Asset asset)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee t)
        {
            try
            {
                if (t == null)
                {
                    throw new NotImplementedException();
                }

                Employee employee = FindByDni(t.Dni);

                if (employee == null)
                {
                    throw new NotImplementedException($"El objeto asset con Id {t.Id} no existe");
                }
                employee.Dni = t.Dni;
                employee.Dni = t.Email;
                employee.Names = t.Names;
                employee.Phone = t.Phone;
               employee.Status = t.Status;
                employee.Lastnames = t.Lastnames;
                employee.Id = t.Id;
               
                depreciationDbContext.Employees.Update(employee);
                return depreciationDbContext.SaveChanges();



            }
            catch
            {
                throw;
            }


        }

        private void ValidateEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException("El objeto employee no puede ser null.");
            }

            if (string.IsNullOrWhiteSpace(employee.Email))
            {
                throw new Exception("El email no puede ser null o vacio.");
            }

            if (string.IsNullOrWhiteSpace(employee.Names))
            {
                throw new Exception("El nombre del empleado no puede ser null o vacio.");
            }
        }
    }
}
