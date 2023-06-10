import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/presentation/router/router_provider.dart';
import 'package:practice/presentation/views/settings_screen.dart';
import 'package:test/test.dart';

void main() {
  final container = ProviderContainer(overrides: []);
  group('Router', () {
    test('Initial path', () {
      final test = container.read(goRouterProvider);
      expect('/', test.location);
    });
    test('Settings path', () {
      final test = container.read(goRouterProvider);
      Widget testWidget(BuildContext context, WidgetRef ref) {
        context.go(Screens.settings.goPath);
        Object result = 'some val';
        context.pop([result]);
        expect(true, result is SettingsScreen);
        return MaterialApp.router(
          routerConfig: test,
        );
      }
    });
  });
}
