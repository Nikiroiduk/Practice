class Region {
  final int id;
  final String name;

  Region({this.id = -1, required this.name});

  Map<String, dynamic> toMap() {
    return {
      "name": name,
    };
  }

  static Region fromMap(Map<String, dynamic> map) {
    return Region(
      id: map["id"],
      name: map["name"],
    );
  }

  @override
  String toString() {
    return "id: $id, name: $name";
  }
}
