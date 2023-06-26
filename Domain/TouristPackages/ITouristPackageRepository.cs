namespace Domain.TouristPackages;

public interface ITouristPackageRepository
{

    Task<TouristPackage?> GetByIdWithLineItemAsync(TouristPackageId id);
    bool HasOneLineItem(TouristPackage touristpackage);

    void Add(TouristPackage touristpackage);
}