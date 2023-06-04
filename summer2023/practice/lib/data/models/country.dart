import 'export.dart';

class Country {
  final int id;
  final String name;
  final List<Export> exports;

  Country({required this.id, required this.name, required this.exports});
}
