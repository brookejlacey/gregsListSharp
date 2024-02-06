namespace gregsListSharp.Services;



public class HousesService(HousesRepository repo)
{
    private readonly HousesRepository repo = repo;

    internal House CreateHouse(House houseData)
    {
        House house = repo.CreateHouse(houseData);
        return house;
    }

    internal List<House> GetAllHouses()
    {
        List<House> houses = repo.GetAllHouses();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        House house = repo.GetHouseById(houseId);
        if (house == null) throw new Exception($"no house with id: {houseId}");
        return house;
    }

    internal string RemoveHouse(int houseId)
    {
        House original = GetHouseById(houseId);
        repo.RemoveHouse(houseId);
        return $"{original.Neighborhood} {original.Color} was removed.";
    }

    internal House UpdateHouse(House updateData)
    {
        House original = GetHouseById(updateData.Id);
        original.Neighborhood ??= updateData.Neighborhood;
        original.YearBuilt ??= updateData.YearBuilt;

        original.Price = updateData.Price != 0 ? updateData.Price : original.Price; // Because price is not Nullable, we have to check it differently
        original.Color ??= updateData.Color;
        original.Description ??= updateData.Description;
        original.ImgUrl ??= updateData.ImgUrl;

        House update = repo.UpdateHouse(original);
        return update;
    }
}