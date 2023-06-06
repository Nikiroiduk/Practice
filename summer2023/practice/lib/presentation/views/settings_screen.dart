import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/data/literally_data.dart';
import 'package:practice/data/providers.dart';

class SettingsScreen extends StatelessWidget {
  const SettingsScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Settings')),
      body: SingleChildScrollView(child: Consumer(
        builder: (context, ref, child) {
          return Padding(
            padding: const EdgeInsets.all(8.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                ElevatedButton(
                  onPressed: () async {
                    for (var region in LiterallyData.regionsData) {
                      ref.read(repositoryProvider).insertRegion(region);
                    }
                    for (var country in LiterallyData.countriesData) {
                      ref.read(repositoryProvider).insertCountry(country);
                    }
                    for (var exports in LiterallyData.exportsData) {
                      for (var export in exports){
                        ref.read(repositoryProvider).insertExport(export);
                      }
                    }
                  },
                  child: const Text('Load data into DB'),
                ),
                ElevatedButton(
                  onPressed: () {
                    ref.read(repositoryProvider).removeDb();
                  },
                  child: const Text('Remove DB'),
                ),
              ],
            ),
          );
        },
      )),
    );
  }
}
