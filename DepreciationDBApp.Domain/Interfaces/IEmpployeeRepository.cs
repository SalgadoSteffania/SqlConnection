using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Interfaces
{
public interface IEmpployeeRepository : IRepository<Employee>
    {

        Employee FindByOni(string dni);
        Employee FindByEmail(string email);
        IEnumerable<Employee> FindByLastNames(string Lastnames);









    }
}
