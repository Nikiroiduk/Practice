import 'country.dart';

class Region {
  final int id;
  final String name;
  final List<Country> countries;

  Region({required this.id, required this.name, required this.countries});
}
