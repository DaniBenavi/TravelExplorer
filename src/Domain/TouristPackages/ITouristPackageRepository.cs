namespace Domain.TouristPackages;

public interface ITouristPackageRepository
{

    Task<TouristPackage?> GetByIdWithLineItemAsync(TouristPackageId id);
    Task<bool> ExistsAsync(TouristPackageId id);
    bool HasOneLineItem(TouristPackage touristpackage);
    Task<List<TouristPackage>> GetAll();
    void Add(TouristPackage touristpackage);
    void Update(TouristPackage touristpackage);
    void Delete(TouristPackage touristpackage);
    Task<TouristPackage?> GetByIdAsync(TouristPackageId id);
}