import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/data/models/models.dart';
import 'package:practice/data/providers.dart';
import 'package:practice/data/repository/db_repository.dart';
import 'package:practice/data/services/db_actions.dart';
import 'package:sqflite_common/sqlite_api.dart';
import 'package:test/test.dart';

void main() {
  ProviderContainer(overrides: [
    databaseProvider.overrideWith((ref) => FakeDBProvider()),
    repositoryProvider
        .overrideWith((ref) => DbRepository(ref.watch(databaseProvider))),
  ]);
  group('DbProvider', () {
    test('GetAllCountries', () {
      Widget testWidget(BuildContext context, WidgetRef ref) {
        var ctr = ref.read(repositoryProvider).getAllCountries();
        expect([
          {'name': 'country1'}
        ], ctr);
        return const MaterialApp();
      }
    });
    test('InsertRegion', () {
      Widget testWidget(BuildContext context, WidgetRef ref) {
        var ctr =
            ref.read(repositoryProvider).insertRegion(Region(name: 'region1'));
        expect(Region(name: 'region1').toMap(), ctr);
        return const MaterialApp();
      }
    });
  });
}

class FakeDBProvider implements DbAction {
  @override
  Future<ResponseEntityList> allCountries() {
    return Future.value([
      {'name': 'country1'},
    ]);
  }

  @override
  Future<ResponseEntityList> allExports() {
    // TODO: implement allExports
    throw UnimplementedError();
  }

  @override
  Future<ResponseEntityList> allRegions() {
    // TODO: implement allRegions
    throw UnimplementedError();
  }

  @override
  // TODO: implement db
  Future<Database> get db => throw Exception('Something went wrong with DB');

  @override
  Future<void> deleteDatabase({name = "my_db.db"}) {
    // TODO: implement deleteDatabase
    throw UnimplementedError();
  }

  @override
  Future<ResponseEntity> insertCountry(ResponseEntity country) {
    // TODO: implement insertCountry
    throw UnimplementedError();
  }

  @override
  Future<ResponseEntity> insertExport(ResponseEntity export) {
    // TODO: implement insertExport
    throw UnimplementedError();
  }

  @override
  Future<ResponseEntity> insertRegion(ResponseEntity region) {
    ResponseEntity result = {};
    for (var element in region.entries) {
      result.addAll({element.key: element.value});
    }
    return Future.value(result);
  }
}
