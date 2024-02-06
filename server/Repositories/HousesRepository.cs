
namespace gregsListSharp.Repositories;

public class HousesRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal House CreateHouse(House houseData)
    {
        string sql = @"
        INSERT INTO houses
        (neighborhood, color, description, imgUrl, price, yearBuilt)
        VALUES
        (@neighborhood, @color, @description, @imgUrl, @price, @yearBuilt);
        
        SELECT
        *
        FROM houses
        WHERE id = LAST_INSERT_ID();
        ";
        House house = db.Query<House>(sql, houseData).FirstOrDefault();
        return house;
    }

    internal List<House> GetAllHouses()
    {
        string sql = @"
            SELECT
            *
            FROM houses;
        ";

        List<House> houses = db.Query<House>(sql).ToList();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        string sql = @"
        SELECT
        *
        FROM houses
        WHERE id = @houseId;
        ";
        House house = db.Query<House>(sql, new { houseId }).FirstOrDefault();
        return house;
    }

    internal void RemoveHouse(int houseId)
    {
        string sql = @"
        DELETE FROM houses
        WHERE id = @houseId;
        ";
        db.Execute(sql, new { houseId });
    }

    internal House UpdateHouse(House updateData)
    {
        string sql = @"
        UPDATE houses SET
        neighborhood = @neighborhood,
        color = @color,
        description = @description,
        imgUrl = @imgUrl,
        price = @price,
        yearBuilt = @yearBuilt
        WHERE id = @id;

        SELECT
        *
        FROM houses
        WHERE id = @id;
        ";
        House house = db.Query<House>(sql, updateData).FirstOrDefault();
        return house;
    }

}