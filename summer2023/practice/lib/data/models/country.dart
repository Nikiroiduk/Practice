class Country {
  final int id;
  final String name;
  final int regionId;

  Country({this.id = -1, required this.name, required this.regionId});

  Map<String, dynamic> toMap() {
    return {
      "name": name,
      "region_id": regionId,
    };
  }

  static Country fromMap(Map<String, dynamic> map) {
    return Country(
      id: map["id"],
      name: map["name"],
      regionId: map["region_id"],
    );
  }

  @override
  String toString() {
    return "id: $id, name: $name, regionId: $regionId";
  }
}
