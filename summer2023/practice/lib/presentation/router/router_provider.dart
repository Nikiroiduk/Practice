import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';

import '../views/views.dart';

final _key = GlobalKey<NavigatorState>();

final goRouterProvider = Provider<GoRouter>((ref) {
  return GoRouter(
    navigatorKey: _key,
    initialLocation: Screens.home.path,
    routes: [
      GoRoute(
          path: Screens.home.path,
          name: Screens.home.name,
          builder: (context, state) => const HomeScreen(),
          routes: [
            GoRoute(
              parentNavigatorKey: _key,
              path: Screens.settings.path,
              name: Screens.settings.name,
              builder: (context, state) => const SettingsScreen(),
            ),
          ]),
    ],
  );
});

enum Screens {
  home,
  settings,
}

extension ScreensX on Screens {
  String get path {
    switch (this) {
      case Screens.home:
        return '/';
      case Screens.settings:
        return 'settings';
      default:
        return '/';
    }
  }

  String get goPath {
    switch (this) {
      case Screens.home:
        return '/';
      case Screens.settings:
        return '/settings';
      default:
        return '/';
    }
  }

  String get name {
    switch (this) {
      case Screens.home:
        return 'Home';
      case Screens.settings:
        return 'Settings';
      default:
        return '';
    }
  }
}
