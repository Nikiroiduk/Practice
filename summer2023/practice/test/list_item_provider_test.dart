import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/presentation/models/list_item.dart';
import 'package:test/test.dart';

void main() {
  var items = <ListItem>[];
  ProviderContainer(overrides: [
    listItemProvider.overrideWith((ref) => FakeListItemNotifier(ref))
    // databaseProvider.overrideWith((ref) => FakeDBProvider()),
    // repositoryProvider
    //     .overrideWith((ref) => DbRepository(ref.watch(databaseProvider))),
  ]);
  group('ListItemProvider', () {
    test('ExerciseOne', () {
      Widget testWidget(BuildContext context, WidgetRef ref) {
        items = ref.watch(listItemProvider);
        ref
            .read(listItemProvider.notifier)
            .exerciseOneFilter(test: true, data: FakeListItemNotifier.data);
        final sortedList = FakeListItemNotifier.data
            .where((element) => element.year == 2004)
            .toList();
        sortedList.sort((a, b) => a.quantity.compareTo(b.quantity));
        expect(sortedList, items);
        return const MaterialApp();
      }
    });
    test('ExerciseTwo', () {
      Widget testWidget(BuildContext context, WidgetRef ref) {
        items = ref.watch(listItemProvider);
        ref
            .read(listItemProvider.notifier)
            .exerciseTwoFilter(test: true, data: FakeListItemNotifier.data);
        final sortedList = FakeListItemNotifier.data
            .where(
                (element) => (element.year == 2010 && element.quantity >= 1000))
            .toList();
        expect(sortedList, items);
        return const MaterialApp();
      }
    });
    test('ExerciseThree', () {
      Widget testWidget(BuildContext context, WidgetRef ref) {
        items = ref.watch(listItemProvider);
        ref
            .read(listItemProvider.notifier)
            .exerciseThreeFilter(test: true, data: FakeListItemNotifier.data);
        final sortedList = FakeListItemNotifier.data
            .where(
                (element) => element.year == 2010 && element.quantity <= 2000)
            .toList();
        expect(sortedList, items);
        return const MaterialApp();
      }
    });
  });
}

class FakeListItemNotifier extends ListItemNotifier {
  static List<ListItem> data = <ListItem>[
    ListItem(region: 'region1', country: 'country1', year: 2004, quantity: 888),
    ListItem(region: 'region2', country: 'country2', year: 2008, quantity: 11),
    ListItem(
        region: 'region3', country: 'country3', year: 2010, quantity: 5124),
    ListItem(region: 'region4', country: 'country4', year: 2010, quantity: 432),
  ];

  FakeListItemNotifier(super._ref) {
    _init();
  }

  _init() async {
    List<ListItem> result = await getData();
    state = result;
  }

  @override
  Future<List<ListItem>> getData() {
    return Future.value(data);
  }
}
