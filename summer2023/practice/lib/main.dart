
import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
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
        body: Consumer(
          builder: (context, ref, child) => Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              ElevatedButton(
                  onPressed: () {
                    ref.read(repositoryProvider).createMockExports(10);
                  },
                  child: const Text('Insert data')),
              ElevatedButton(
                  onPressed: () {
                    ref.read(repositoryProvider).getAllExports();
                  },
                  child: const Text('Load data')),
            ],
          ),
        ),
      ),
    );
  }
}
