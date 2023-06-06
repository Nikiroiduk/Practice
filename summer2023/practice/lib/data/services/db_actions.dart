import 'package:path/path.dart';
import 'package:practice/data/services/db_connection.dart';
import 'package:sqflite/sqflite.dart';


typedef ResponseEntity = Map<String, dynamic>;
typedef ResponseEntityList = List<ResponseEntity>;

class DbAction {
  Future<Database> get db async {
    var base = await DbConnection.getDbConnect();
    if (base == null) {
      throw Exception('Something went wrong with DB');
    }
    return base;
  }

  Future<ResponseEntityList> allExports() async {
    var base = await db;
    return base.query(DbConnection.exportTable);
  }

  Future<ResponseEntityList> allCountries() async {
    var base = await db;
    return base.query(DbConnection.countryTable);
  }

  Future<ResponseEntityList> allRegions() async {
    var base = await db;
    return base.query(DbConnection.regionTable);
  }

  Future<ResponseEntity> insertExport(final ResponseEntity export) async {
    final base = await db;
    late final ResponseEntity exportEntity;
    await base.transaction((txn) async {
      final id = await txn.insert(DbConnection.exportTable, export,
          conflictAlgorithm: ConflictAlgorithm.replace);
      final results = await txn
          .query(DbConnection.exportTable, where: "id = ?", whereArgs: [id]);
      exportEntity = results.first;
    });
    return exportEntity;
  }

  Future<ResponseEntity> insertCountry(final ResponseEntity country) async {
    final base = await db;
    late final ResponseEntity countryEntity;
    await base.transaction((txn) async {
      final id = await txn.insert(DbConnection.countryTable, country,
          conflictAlgorithm: ConflictAlgorithm.replace);
      final results = await txn
          .query(DbConnection.countryTable, where: "id = ?", whereArgs: [id]);
      countryEntity = results.first;
    });
    return countryEntity;
  }

    Future<ResponseEntity> insertRegion(final ResponseEntity region) async {
    final base = await db;
    late final ResponseEntity regionEntity;
    await base.transaction((txn) async {
      final id = await txn.insert(DbConnection.regionTable, region,
          conflictAlgorithm: ConflictAlgorithm.replace);
      final results = await txn
          .query(DbConnection.regionTable, where: "id = ?", whereArgs: [id]);
      regionEntity = results.first;
    });
    return regionEntity;
  }

  Future<void> deleteDatabase() async =>
    databaseFactory.deleteDatabase(join(await getDatabasesPath(), "my_db.db"));
}
