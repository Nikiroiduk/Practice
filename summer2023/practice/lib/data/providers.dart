import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:practice/data/repository/db_repository.dart';
import 'package:practice/data/repository/i_db_repository.dart';
import 'package:practice/data/services/db_actions.dart';

// TODO: DbAction interface?
final databaseProvider = Provider<DbAction>((_) => DbAction());
final repositoryProvider =
    Provider<IDbRepository>((ref) => DbRepository(ref.watch(databaseProvider)));
