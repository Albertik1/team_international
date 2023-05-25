using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    public static class QueriesStore
    {
        public static void Example()
        {
            int[] n = { 1, 3, 5, 6, 3, 6, 7, 8, 45, 3, 7, 6 };

            IEnumerable<int> res;
            res = n.OrderByDescending(g => g).Skip(3);
            res = n.OrderByDescending(g => g).Take(3);
            res = n.Select(g => g * 2);
            res = n.TakeWhile(g => g != 45).Concat(n.SkipWhile(s => s != 45).Skip(1));
        }

        public static string Query2(IEnumerable<string> str)
        {
            return str.Aggregate((accumulated, next) => accumulated + next);
        }

        public static string Query3(int l, IEnumerable<string> str)
        {
            var result = str.FirstOrDefault(s => s.Length == l && char.IsDigit(s[0]));
            return result ?? "Not found";
        }

        public static int Query4(char c, IEnumerable<string> str)
        {
            var result = str.Count(s => s.Length > 1 && s[0] == c && s[s.Length - 1] == c);
            return result;
        }

        public static int Query5(IEnumerable<string> str)
        {
            var result = str.Sum(s => s.Length);
            return result;
        }

        public static string Query6(IEnumerable<string> str)
        {
            return str
                .Where(s => !string.IsNullOrEmpty(s))
                .Aggregate(string.Empty, (result, next) => result + next[0]);
        }

        public static IEnumerable<int> Query7(int k, IEnumerable<int> a)
        {
            var firstPart = a.Where(x => x % 2 == 0);
            var secondPart = a.Skip(k);

            var result = firstPart.Except(secondPart).Distinct().Reverse();
            return result;
        }

        public static IEnumerable<string> Query8(int k, IEnumerable<string> a)
        {
            var result = a
                .Where(s => s.Length == k && char.IsDigit(s[s.Length - 1]))
                .OrderBy(s => s);

            return result;
        }

        public static IEnumerable<int> Query9(int d, int k, IEnumerable<int> a)
        {
            var firstFragment = a.TakeWhile(x => x <= d);
            var secondFragment = a.Skip(k - 1);
            var result = firstFragment.Union(secondFragment).Distinct().OrderByDescending(x => x);
            return result;
        }

        public static IEnumerable<string> Query10(IEnumerable<int> n)
        {
            var result = n.Where(x => x % 2 == 1)
                          .Select(x => x.ToString())
                          .OrderBy(x => x);
            return result;
        }

        public static IEnumerable<char> Query11(IEnumerable<string> str)
        {
            var result = str.Select(s => s.Length % 2 == 1 ? s[0] : s[s.Length - 1])
                            .OrderByDescending(c => c);
            return result;
        }

        public static IEnumerable<int> Query12(int k1, int k2, IEnumerable<int> a, IEnumerable<int> b)
        {
            var result = a.Where(x => x > k1)
                          .Concat(b.Where(x => x < k2))
                          .OrderBy(x => x);

            return result;
        }

        public static IEnumerable<string> Query13(IEnumerable<int> a, IEnumerable<int> b)
        {
            var innerUnion = from x in a
                             join y in b on x % 10 equals y % 10
                             select $"{x} - {y}";

            return innerUnion;
        }

        public static IEnumerable<string> Query14(IEnumerable<string> a, IEnumerable<string> b)
        {
            var innerUnion = from x in a
                             join y in b on x.Length equals y.Length
                             orderby x ascending, y descending
                             select $"{x}:{y}";
            return innerUnion;
        }

        public static IEnumerable<string> Query15(IEnumerable<int> a)
        {
            var groups = a.GroupBy(n => n % 10);

            var result = groups.OrderBy(g => g.Key)
                .Select(g => $"{g.Key}: {g.Sum()}");

            return result;
        }

        public static IDictionary<uint, int> Query16(IEnumerable<Enrollee> enrollees)
        {
            var result = enrollees
                      .GroupBy(e => e.YearGraduate)
                      .ToDictionary(
                           g => g.Key,
                           g => g.Select(e => e.SchoolNumber).Count()
      );

            return result.OrderBy(kvp => kvp.Key).ThenBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            throw new NotImplementedException();
        }
    }
}
