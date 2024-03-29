﻿using WineSales.Domain.Models;

namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ISaleRepository : ICrudRepository<Sale>
    {
        List<Sale> GetBySellingPrice(double sellingPrice);
        List<Sale> GetByPurchasePrice(double purchasePrice);
        List<Sale> GetByProfit(double profit);
        List<Sale> GetByWineNumber(int wineNumber);
        List<Sale> GetByDate(DateOnly date);
        List<Sale> GetBySupplierWineID(int supplierWineID);
    }
}
