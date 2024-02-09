using System;
namespace AlgorithmSolutions
{
    public class Turing
    {
        public static void Main()
        {
            var ss = "({})";
            Console.WriteLine(IsValid(ss));
            var dd = new string[] { "5", "2", "C", "D", "+", "+" };
            //output = 50
            Console.WriteLine(Score(dd));
            var cd = new int[][] { new int[] { 5, 7, 3, 9, 4, 9, 8, 3, 1 }, new int[] { 1, 2, 2, 4, 4, 1 }, new int[] { 1, 2, 3 } };
            //output = 8
            var cd2 = new int[][] { new int[] { 5, 7, 3 }, new int[] { 1, 2, 2 }, new int[] { 1, 2, 3 } };
            //output = -1
            Console.WriteLine(WiningCard(cd2));
        }
        static bool IsValid(string str)
        {
            var op = new List<char> { '(', '{', '[' };
            var cl = new List<char> { ')', '}', ']' };
            var stk = new Stack<char>();
            if (cl.Contains(str[0]))
                return false;
            foreach (var c in str)
            {
                if (op.Contains(c))
                {
                    stk.Push(c);
                }
                else if (stk.Count == 0)
                    return false;
                else
                {
                    var index = cl.IndexOf(c);
                    if (op[index] == stk.Peek())
                        stk.Pop();
                    else
                    {
                        return false;
                    }

                }

            }
            return stk.Count == 0;
        }

        static int Score(string[] cha)
        {
            var score = new Stack<int>();
            var result = 0;
            int lst = 0;
            foreach (var c in cha)
            {
                int n;
                if (int.TryParse(c, out n))
                {
                    score.TryPeek(out lst);
                    score.Push(n);
                }
                if (c == "C")
                {
                    score.Pop();
                }
                if (c == "D")
                {
                    var cc = score.Peek();
                    lst = cc;
                    score.Push(2 * cc);
                }
                if (c == "+")
                {
                    var cc = score.Peek();
                    score.Push(lst + cc);
                }
            }

            while (score.Count > 0)
            {
                //Console.WriteLine(score.Peek());
                result += score.Pop();
            }

            return result;
        }

        static int WiningCard(int[][] cards)
        {
            var ls = cards.ToList();
            Console.WriteLine("====================");
            ls.OrderBy(x => x.Count());
            Console.WriteLine("====================");
            var lowCount = ls[1];
            Console.WriteLine($"===================={lowCount.Count()} ");
            var highCount = ls[0];
            Console.WriteLine($"===================={highCount.Count()}");

            return highCount.Count() - lowCount.Count() == 0 ? -1 : highCount[lowCount.Count()];
        }

        static int DecodeStringToNumber(string s)
        {

            //var s = "@@##~";
            //output = 1007
            var dic = new Dictionary<char, int>() { { '@', 1 }, { '#', 5 }, { '$', 10 }, { '%', 50 }, { '&', 100 }, { '+', 500 }, { '~', 1000 } };
            var dicount = new Dictionary<char, int>();
            var i = 0;
            var j = s.Length - 1;
            while (i < j)
            {
                if (dicount.ContainsKey(s[i]))
                {
                    dicount[s[i]]++;
                }
                else
                {
                    dicount.Add(s[i], 1);
                }
                if (dicount.ContainsKey(s[j]))
                {
                    dicount[s[j]]++;
                }
                else
                {
                    dicount.Add(s[j], 1);
                }

                i++;
                j--;
            }
            var sum = 0;
            foreach (var item in dicount)
            {
                var valu = dic[item.Key];
                sum += (valu * item.Value);
            }
            return sum;
        }
    }
}

