import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/data/literally_data.dart';
import 'package:practice/data/providers.dart';

void main() {
  runApp(const ProviderScope(child: MainApp()));
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      themeMode: ThemeMode.dark,
      theme: ThemeData.dark(useMaterial3: true),
      home: Scaffold(
        body: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Consumer(
            builder: (context, ref, child) => Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                ElevatedButton(
                    onPressed: () async {
                      var reg =
                          await ref.read(repositoryProvider).getAllRegions();
                      for (var region in reg) {
                        print(region);
                      }
                    },
                    child: const Text('Load Regions')),
                    ElevatedButton(
                    onPressed: () async {
                      var ctr =
                          await ref.read(repositoryProvider).getAllCountries();
                      for (var country in ctr) {
                        print(country);
                      }
                    },
                    child: const Text('Load Countries')),
                    ElevatedButton(
                    onPressed: () async {
                      var exp =
                          await ref.read(repositoryProvider).getAllExports();
                      for (var export in exp) {
                        print(export);
                      }
                    },
                    child: const Text('Load Exports')),
                ElevatedButton(
                    onPressed: () async {
                      for (var region in LiterallyData.regionsData) {
                        var reg = await ref
                            .read(repositoryProvider)
                            .insertRegion(region);
                        print(reg);
                      }
                    },
                    child: const Text('Add Regions')),
                ElevatedButton(
                    onPressed: () async {
                      for (var country in LiterallyData.countriesData) {
                        var ctr = await ref
                            .read(repositoryProvider)
                            .insertCountry(country);
                        print(ctr);
                      }
                    },
                    child: const Text('Add Countries')),
                ElevatedButton(
                    onPressed: () async {
                      for (var exportData in LiterallyData.exportsData) {
                        for (var export in exportData) {
                          var exp = await ref
                              .read(repositoryProvider)
                              .insertExport(export);
                          print(exp);
                        }
                      }
                    },
                    child: const Text('Add Exports')),
                ElevatedButton(
                    onPressed: () async {
                      ref.read(repositoryProvider).removeDb();
                    },
                    child: const Text('Remove DB')),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
