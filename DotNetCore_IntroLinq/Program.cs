using Tools;

using System.Linq.Expressions;
using System.Data;

namespace DotNetCore_IntroLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            ConstantExpression constantZero = Expression.Constant(0);
            ConstantExpression constantTwo = Expression.Constant(2);
            ParameterExpression parameterX = Expression.Parameter(typeof(int), "x");

            BinaryExpression modulo = Expression.Modulo(parameterX, constantTwo);
            BinaryExpression equal = Expression.Equal(modulo, constantZero);
            LambdaExpression lambda = Expression.Lambda(equal, parameterX);

            Func<int, bool>? func = lambda.Compile() as Func<int, bool>;

            Expression<Func<int, bool>> expression = (x) => x % 2 == 0;

            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            myExpressionVisitor.Visit(expression);

            //if (func is not null)
            //{
            //    int[] dentier = { 0, 11, 21, 32, 4, 56, 6, 70, 82, 9 };
            //    IEnumerable<int> list = Operators.Get(dentier, func);

            //    foreach (int item in list)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //int[] dentier = { 0, 11, 21, 32, 4, 56, 6, 70, 82, 9 };
            //IEnumerable<int> list = Operators.Get(dentier, (x) => x % 2 == 0);

            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //List<string> prenoms = new List<string>() { "Serge", "Francois", "Jonathan", "Stephane", "Julien", "Olivier", "Amory", "Thierry" };
            //IEnumerable<string> selectedPrenoms = prenoms.Get((x) => !x.ToUpper().Contains('E'));

            //foreach (string item in selectedPrenoms)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<int> lengths = prenoms
            //    .Get((x) => !x.ToUpper().Contains('E'))
            //    .Transform((p) => p.Length);

            //prenoms.Add("Paul");

            //foreach (int item in lengths)
            //{
            //    Console.WriteLine(item);
            //}

            //prenoms.Add("Loana");

            //using (IEnumerator<int> enumerator = lengths.GetEnumerator())
            //{
            //    while(enumerator.MoveNext())
            //    {
            //        int item = enumerator.Current;

            //        Console.WriteLine(item);
            //    }
            //}
        }             
    }
}