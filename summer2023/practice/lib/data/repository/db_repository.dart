import 'package:practice/data/repository/i_db_repository.dart';
import 'package:practice/data/services/db_actions.dart';

import '../models/models.dart';

class DbRepository implements IDbRepository {
  final DbAction database;

  const DbRepository(this.database);

  @override
  Future<ResponseEntityList> getAllCountries() async {
    // TODO: implement getAllCountries
    throw UnimplementedError();
  }

  @override
  Future<List<Export>> getAllExports() async {
    final countriesListEntity = await database.allExports();
    print(countriesListEntity);
    return countriesListEntity.map((e) => Export.fromMap(e)).toList();
  }

  @override
  Future<ResponseEntityList> getAllRegions() async {
    // TODO: implement getAllRegions
    throw UnimplementedError();
  }

  @override
  Future<bool> createMockExports(int quantity) async {
    for (var i = 0; i < quantity; i++) {
      var r = await database.meh();
      print('$i: $r');
      if (r != true) return false;
    }
    return true;
  }
}
