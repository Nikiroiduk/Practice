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
      onCreate: (db, version) => _createDb(db),
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

  static void _createDb(Database db) {
    db.execute('''CREATE TABLE $regionTable (
          id integer PRIMARY KEY AUTOINCREMENT,
          name text NOT NULL
        );''');

    db.execute('''CREATE TABLE $countryTable (
          id integer PRIMARY key AUTOINCREMENT,
          name text NOT NULL,
          region_id integer NOT NULL,
          FOREIGN KEY(region_id) REFERENCES $regionTable(id)
        );''');

    db.execute('''CREATE TABLE $exportTable (
          id integer PRIMARY key AUTOINCREMENT,
          year integer NOT NULL,
          quantity real NOT NULL,
          country_id integer NOT NULL,
          FOREIGN KEY(country_id) REFERENCES $countryTable(id)
        );''');
  }
}
