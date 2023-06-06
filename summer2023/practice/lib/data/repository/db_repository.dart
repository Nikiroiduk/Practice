import 'package:practice/data/repository/i_db_repository.dart';
import 'package:practice/data/services/db_actions.dart';

import '../models/models.dart';

class DbRepository implements IDbRepository {
  final DbAction database;

  const DbRepository(this.database);

  @override
  Future<List<Country>> getAllCountries() async {
    final countriesListEntity = await database.allCountries();
    return countriesListEntity.map((e) => Country.fromMap(e)).toList();
  }

  @override
  Future<List<Export>> getAllExports() async {
    final exportsListEntity = await database.allExports();
    return exportsListEntity.map((e) => Export.fromMap(e)).toList();
  }

  @override
  Future<List<Region>> getAllRegions() async {
    final regionsListEntity = await database.allRegions();
    return regionsListEntity.map((e) => Region.fromMap(e)).toList();
  }

  @override
  Future<Country> insertCountry(Country country) async {
    final responseEntity = await database.insertCountry(country.toMap());
    return Country.fromMap(responseEntity);
  }

  @override
  Future<Export> insertExport(Export export) async {
    final responseEntity = await database.insertExport(export.toMap());
    return Export.fromMap(responseEntity);
  }

  @override
  Future<Region> insertRegion(Region region) async {
    final responseEntity = await database.insertRegion(region.toMap());
    return Region.fromMap(responseEntity);
  }

  @override
  Future<void> removeDb() async {
    print('Removing DB...');
    return database.deleteDatabase();
  }
}
