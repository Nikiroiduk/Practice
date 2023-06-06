class Export {
  late final int id;
  final int year;
  final double quantity;
  final int countryId;

  Export(
      {required this.year,
      required this.quantity,
      this.id = -1,
      required this.countryId});

  Map<String, dynamic> toMap() {
    return {
      "year": year,
      "quantity": quantity,
      "country_id": countryId,
    };
  }

  static Export fromMap(Map<String, dynamic> map) {
    return Export(
      id: map["id"],
      year: map["year"],
      quantity: map["quantity"],
      countryId: map["country_id"],
    );
  }

  @override
  String toString() {
    return "id: $id, year: $year, quantity: $quantity, countryId: $countryId";
  }
}
