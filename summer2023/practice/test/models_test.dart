import 'package:practice/data/models/models.dart';
import 'package:practice/presentation/models/list_item.dart';
import 'package:test/test.dart';

void main() {
  group('Models', () {
    test('ListItem', () {
      const rName = 'region1';
      const cName = 'country1';
      const eYear = 2001;
      const eQuantity = 1.0;
      final region = Region(
        name: rName,
      );
      final country = Country(
        name: cName,
        regionId: region.id,
      );
      final export = Export(
        year: eYear,
        quantity: eQuantity,
        countryId: country.id,
      );

      var lsItem = ListItem.db(
        country: country,
        region: region,
        export: export,
      );

      expect(
          ListItem(
            country: country.name,
            region: region.name,
            year: export.year,
            quantity: export.quantity,
          ),
          lsItem);
    });
    test('Region', () {
      var r = Region(name: 'regionName');
      var r1 = Region(name: 'regionName');

      expect(true, r == r1);
    });
  });
}
