using AutoMapper;

using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISupplierInteractor
    {
        SupplierBL CreateSupplier(SupplierBL supplier);
        List<SupplierBL> GetAll();
        SupplierBL GetByID(int id);
        SupplierBL GetByName(string name);
        SupplierBL GetBySupplierWineID(int supplierWineID);
        SupplierBL UpdateSupplier(SupplierBL supplier);
        SupplierBL DeleteSupplier(int id);
    }

    public class SupplierInteractor : ISupplierInteractor
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierInteractor(ISupplierRepository supplierRepository,
                                  IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public SupplierBL CreateSupplier(SupplierBL supplier)
        {
            if (IsExistByName(supplier.Name))
                throw new SupplierException("This supplier already exists.");

            supplier.License = false;

            var transmittedSupplier = _mapper.Map<Supplier>(supplier);
            return _mapper.Map<SupplierBL>(_supplierRepository.Create(transmittedSupplier));
        }

        public List<SupplierBL> GetAll()
        {
            return _mapper.Map<List<SupplierBL>>(_supplierRepository.GetAll());
        }

        public SupplierBL GetByID(int id)
        {
            return _mapper.Map<SupplierBL>(_supplierRepository.GetByID(id));
        }

        public SupplierBL GetByName(string name)
        {
            return _mapper.Map<SupplierBL>(_supplierRepository.GetByName(name));
        }

        public SupplierBL GetBySupplierWineID(int supplierWineID)
        {
            return _mapper.Map<SupplierBL>(_supplierRepository.GetBySupplierWineID(supplierWineID));
        }

        public SupplierBL UpdateSupplier(SupplierBL supplier)
        {
            if (!IsExistById(supplier.ID))
                return null;

            if (IsNameTaken(supplier.ID, supplier.Name))
                throw new SupplierException("This name is already taken.");

            var transmittedSupplier = _mapper.Map<Supplier>(supplier);
            return _mapper.Map<SupplierBL>(_supplierRepository.Update(transmittedSupplier));
        }

        public SupplierBL DeleteSupplier(int id)
        {
            if (!IsExistById(id))
                return null;

            return _mapper.Map<SupplierBL>(_supplierRepository.Delete(id));
        }

        private bool IsExistByName(string name)
        {
            return _supplierRepository.GetByName(name) != null;
        }

        private bool IsExistById(int id)
        {
            return _supplierRepository.GetByID(id) != null;
        }

        private bool IsNameTaken(int id, string name)
        {
            return _supplierRepository.GetAll().Any(obj =>
                                                    obj.ID != id &&
                                                    obj.Name == name);
        }
    }
}
