import 'dart:math';

import 'package:practice/data/services/db_connection.dart';
import 'package:sqflite/sqflite.dart';

import '../models/models.dart';

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

  Future<bool> meh() async {
    var base = await db;
    var res = 0;
    await base.transaction((txn) async {
      res = await txn.insert(
        DbConnection.exportTable,
        Export(year: Random().nextInt(22) + 2000, quantity: (Random().nextDouble() + 1) * 87).toMap(),
        conflictAlgorithm: ConflictAlgorithm.replace,
      );
    });
    return res != 0;
  }
}
