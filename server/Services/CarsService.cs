

namespace gregsListSharp.Services;



public class CarsService(CarsRepository repo)
{
  private readonly CarsRepository repo = repo;

  internal Car CreateCar(Car carData)
  {
    Car car = repo.CreateCar(carData);
    return car;
  }

  internal List<Car> GetAllCars()
  {
    List<Car> cars = repo.GetAllCars();
    return cars;
  }

  internal Car GetCarById(int carId)
  {
    Car car = repo.GetCarById(carId);
    if (car == null) throw new Exception($"no car with id: {carId}");
    return car;
  }

  internal string RemoveCar(int carId)
  {
    Car original = GetCarById(carId);
    // TODO do i own it?
    repo.RemoveCar(carId);
    return $"{original.Make} {original.Model} was removed.";
  }

  internal Car UpdateCar(Car updateData)
  {
    Car original = GetCarById(updateData.Id);
    // TODO do i own it?

    // NULL checking
    original.Make ??= updateData.Make;
    original.Model ??= updateData.Model;
    // original.Year ??= original.Year; If this is not editable either don't pass it here
    original.Price = updateData.Price != 0 ? updateData.Price : original.Price; // Because price is not Nullable, we have to check it differently
    original.Color ??= updateData.Color;
    original.Description ??= updateData.Description;
    original.ImgUrl ??= updateData.ImgUrl;

    Car update = repo.UpdateCar(original);
    return update;
  }
}