import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/presentation/router/router_provider.dart';

void main() {
  runApp(const ProviderScope(child: MainApp()));
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return Consumer(
      builder: (context, ref, child) => MaterialApp.router(
        themeMode: ThemeMode.dark,
        theme: ThemeData.dark(useMaterial3: true),
        routerConfig: ref.watch(goRouterProvider),
      ),
    );
  }
}
