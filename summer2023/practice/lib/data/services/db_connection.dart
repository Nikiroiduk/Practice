import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class DbConnection {
  static Database? db;
  static const String exportTable = 'export';
  static const String countryTable = 'country';
  static const String regionTable = 'region';

  static Future<Database?> initDb() async {
    db = await openDatabase(
      join(await getDatabasesPath(), "my_db.db"),
      onCreate: (db, version) {
        return db.execute('''
        CREATE TABLE $exportTable (
          id integer PRIMARY key AUTOINCREMENT,
          year integer NOT NULL,
          quantity real NOT NULL
        );
        CREATE TABLE $countryTable (
          id integer PRIMARY key AUTOINCREMENT,
          name text NOT NULL,
          export_id integer,
          FOREIGN key(export_id) REFERENCES export(id)
        );
        CREATE TABLE $regionTable (
          id integer PRIMARY KEY AUTOINCREMENT,
          name text NOT NULL,
          country_id integer,
          FOREIGN KEY(country_id) REFERENCES country(id)
        );''');
      },
      version: 1,
    );
    return db;
  }

  static Future<Database?> getDbConnect() async {
    if (db == null) {
      return await initDb();
    } else {
      return db;
    }
  }
}
