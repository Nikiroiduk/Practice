import '../models/models.dart';

abstract class IDbRepository {
  Future<List<Export>> getAllExports();
  Future<List<Country>> getAllCountries();
  Future<List<Region>> getAllRegions();

  Future<Export> insertExport(Export export);
  Future<Country> insertCountry(Country country);
  Future<Region> insertRegion(Region region);

  Future<void> removeDb();
}
