import 'package:practice/data/services/db_actions.dart';

import '../models/models.dart';

abstract class IDbRepository {
  Future<List<Export>> getAllExports();
  Future<ResponseEntityList> getAllCountries();
  Future<ResponseEntityList> getAllRegions();

  Future<bool> createMockExports(int quantity);
}
