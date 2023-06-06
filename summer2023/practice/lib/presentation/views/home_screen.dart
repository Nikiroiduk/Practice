import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';

import '../models/list_item.dart';
import '../router/router_provider.dart';

class HomeScreen extends ConsumerWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    var items = ref.watch(listItemProvider);
    return Scaffold(
      appBar: AppBar(title: const Text('Practice'), actions: [
        IconButton(
          onPressed: () {
            ref.read(listItemProvider.notifier).exerciseOneFilter();
          },
          icon: const Icon(Icons.looks_one_rounded),
        ),
        IconButton(
          onPressed: () {
            ref.read(listItemProvider.notifier).exerciseTwoFilter();

          },
          icon: const Icon(Icons.looks_two_rounded),
        ),
        IconButton(
          onPressed: () {
            ref.read(listItemProvider.notifier).exerciseThreeFilter();

          },
          icon: const Icon(Icons.looks_3_rounded),
        ),
        IconButton(
          onPressed: () {
            ref.read(listItemProvider.notifier).all();

          },
          icon: const Icon(Icons.data_array_rounded),
        ),
        IconButton(
          onPressed: () {
            context.go(Screens.settings.goPath);
          },
          icon: const Icon(Icons.settings_rounded),
        ),
      ]),
      body: SafeArea(
        child: Scrollbar(
          child: ListView.builder(
            physics: const BouncingScrollPhysics(
                parent: AlwaysScrollableScrollPhysics()),
            itemCount: items.length,
            itemBuilder: (context, index) {
              return ListTile(
                isThreeLine: false,
                title: Text(items[index].country),
                subtitle: Text('${items[index].region}\n${items[index].year}'),
                trailing: Text('${items[index].quantity} c.'),
                titleTextStyle: const TextStyle(fontSize: 20),
                subtitleTextStyle: TextStyle(fontSize: 14, foreground: Paint()..color = Colors.white54),
                leadingAndTrailingTextStyle: const TextStyle(fontSize: 16),
                contentPadding: const EdgeInsets.all(8),
              );
            },
          ),
        ),
      ),
    );
  }
}
