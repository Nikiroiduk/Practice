class Export {
  late final int id;
  final int year;
  final double quantity;

  //Export({required this.id, required this.year, required this.quantity});
  Export({required this.year, required this.quantity, this.id = 0});

  Map<String, dynamic> toMap() {
    return {
      "year": year,
      "quantity": quantity,
    };
  }

  static Export fromMap(Map<String, dynamic> map) {
    return Export(
      id: map["id"],
      year: map["year"],
      quantity: map["quantity"],
    );
  }
}
