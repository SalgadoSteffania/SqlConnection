using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            depreciationDbContext.Assets.Add(t);
            depreciationDbContext.SaveChanges();
        }

        public bool Delete(Asset t)
        {


            try
            {
                if(t == null)
                {
                    throw new NotImplementedException("El objeto asset no puede ser null");
                }
                Asset asset = FindById(t.Id);

                if(asset == null)
                {
                    throw new NotImplementedException($"El objeto con ID {t.Id} no existe");
                }

                depreciationDbContext.Assets.Remove(asset);
                int result = depreciationDbContext.SaveChanges();
                return result > 0;


            }
            catch(Exception)
            {
                throw;
            }

            
        }

        public Asset FindByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Asset FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Asset> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {

                    throw new NotImplementedException($"El parametro name ´{name}´ no tiene el formato correcto ");
                }
                return depreciationDbContext.Assets.Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch
            {
                throw;
            }


        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            try
            {
                if(t== null)
                {
                    throw new NotImplementedException();
                }

                Asset asset = FindById(t.Id);

                if(asset == null)
                {
                    throw new NotImplementedException($"El objeto asset con Id {t.Id} no existe");
                }
                asset.Name = t.Name;
                asset.Description = t.Description;
                asset.AmountResidual = t.AmountResidual;
                asset.IsActive = t.IsActive;
                asset.Status = t.Status;

                depreciationDbContext.Assets.Update(asset);
                return depreciationDbContext.SaveChanges();



            }
            catch
            {
                throw;
            }



           
        }// update





    }
}
