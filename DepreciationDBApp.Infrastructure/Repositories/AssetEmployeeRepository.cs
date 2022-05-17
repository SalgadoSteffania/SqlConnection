
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class AssetEmployeeRepository : IAssetEmployeeRepository
    {
        private IDepreciationDbContext depreciationDbContext;
        public void Create(AssetEmployee t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AssetEmployee t)
        {
            throw new NotImplementedException();
        }

        public AssetEmployee FindByAssetEmployeeId(int employeeId, int assedId)
        {
            try
            {
                if(employeeId <= 0)
                {
                    throw new NotImplementedException(" El Id del Empleado no puede ser menor o igual a cero");
                }
                if (assedId <= 0)
                {
                    throw new NotImplementedException("El id no puede ser menor o igual a cero");

                }

                //return DepreciationDBContext.AssetEmployees.FirstOrDefault(x => x.EmployeeId == employeeId && x.Asset == assedId);
                return depreciationDbContext.AssetEmployees.FirstOrDefault(x => x.EmployeeId == employeeId && x.AssetId == assedId);

            }
            catch
            {
                throw;
            }
        }

        public List<AssetEmployee> FindByAssetId(int assetId)
        {
            throw new NotImplementedException();
        }

        public List<AssetEmployee> FindByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<AssetEmployee> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(AssetEmployee t)
        {
            throw new NotImplementedException();
        }
    }
}
