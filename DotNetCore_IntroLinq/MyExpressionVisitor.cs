using System.Linq.Expressions;

namespace DotNetCore_IntroLinq
{
    class MyExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            Console.WriteLine("We have a lambda!!");
            Console.WriteLine("Parameters");
            List<ParameterExpression> parameters = new List<ParameterExpression>();
            foreach (ParameterExpression expression in node.Parameters)
            {
                parameters.Add((ParameterExpression)Visit(expression));
            }

            Console.WriteLine("Body");
            Expression body = Visit(node.Body);

            return Expression.Lambda<T>(body, parameters);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine($"We have a binary expression ('{node.Left.NodeType} node' '{node.NodeType}' '{node.Right.NodeType} node')");
            Console.WriteLine("Left Node :");
            Expression? left = Visit(node.Left);
            Console.WriteLine("Right Node :");
            Expression right = Visit(node.Right);
            return Expression.MakeBinary(node.NodeType, left, right);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.WriteLine($"We have a constant expression {node.Value} of type '{node.Type}'");
            if (node.Value is 0)
                return Expression.Constant(1);
            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Console.WriteLine($"We have a parameter expression {node.Name} of type '{node.Type}'");
            return node;
        }
    }
}
