import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/data/providers.dart';

import '../../data/models/models.dart';

class ListItem {
  late final String region;
  late final String country;
  late final int year;
  late final double quantity;

  ListItem({
    required this.region,
    required this.country,
    required this.year,
    required this.quantity,
  });

  ListItem.db({
    required Region region,
    required Country country,
    required Export export,
  }) {
    this.region = region.name;
    this.country = country.name;
    year = export.year;
    quantity = export.quantity;
  }

  @override
  String toString() {
    return "region: $region, country: $country, year: $year, quantity: $quantity";
  }

  @override
  bool operator ==(Object other) {
    return (other is ListItem) && other.hashCode == hashCode;
  }

  @override
  int get hashCode => '$quantity$year$region$country'.hashCode;
}

final listItemProvider =
    StateNotifierProvider<ListItemNotifier, List<ListItem>>(
        (ref) => ListItemNotifier(ref));

class ListItemNotifier extends StateNotifier<List<ListItem>> {
  ListItemNotifier(this._ref) : super([]) {
    _init();
  }
  final Ref _ref;

  exerciseOneFilter({bool test = false, List<ListItem> data = const []}) async {
    List<ListItem> result = [];
    if (!test) {
      result = await getData();
    } else {
      result = data;
    }
    var tmp = result.where((element) => element.year == 2004).toList();
    tmp.sort((a, b) => a.quantity.compareTo(b.quantity));
    state = tmp;
  }

  exerciseTwoFilter({bool test = false, List<ListItem> data = const []}) async {
    List<ListItem> result = [];
    if (!test) {
      result = await getData();
    } else {
      result = data;
    }
    state = result
        .where((element) => (element.year == 2010 && element.quantity >= 1000))
        .toList();
  }

  exerciseThreeFilter(
      {bool test = false, List<ListItem> data = const []}) async {
    List<ListItem> result = [];
    if (!test) {
      result = await getData();
    } else {
      result = data;
    }
    state = result
        .where((element) => element.year == 2010 && element.quantity <= 2000)
        .toList();
  }

  all() async {
    _init();
  }

  _init() async {
    List<ListItem> result = await getData();
    state = result;
  }

  Future<List<ListItem>> getData() async {
    final regions = await _ref.read(repositoryProvider).getAllRegions();
    final countries = await _ref.read(repositoryProvider).getAllCountries();
    final exports = await _ref.read(repositoryProvider).getAllExports();
    final List<ListItem> result = [];

    for (var region in regions) {
      for (var country
          in countries.where((element) => element.regionId == region.id)) {
        for (var export
            in exports.where((element) => element.countryId == country.id)) {
          result.add(ListItem(
            region: region.name,
            country: country.name,
            year: export.year,
            quantity: export.quantity,
          ));
        }
      }
    }
    return result;
  }
}
