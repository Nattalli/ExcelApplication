using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelApplication
{
    class LabCalculatorVisitor : ExcelApplicationBaseVisitor<double>
{
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        
        private IEnumerable<string> Separate(string input)
        {
            throw new NotImplementedException();
        }

        public override double VisitCompileUnit(ExcelApplicationParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(ExcelApplicationParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }
        //IdentifierExpr
        public override double VisitIdentifierExpr(ExcelApplicationParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            //видобути значення змінної з таблиці
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(ExcelApplicationParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(ExcelApplicationParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(ExcelApplicationParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == ExcelApplicationLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(ExcelApplicationParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == ExcelApplicationLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        }

        public override double VisitUnaryPExpr(ExcelApplicationParser.UnaryPExprContext context)
        {
            var number = WalkLeft(context);
            return number + 1;
        }

        public override double VisitUnaryMExpr(ExcelApplicationParser.UnaryMExprContext context)
        {
            var number  = WalkLeft(context);
                return number - 1;
        }

        public override double VisitMmaxMminExpr(ExcelApplicationParser.MmaxMminExprContext context)
        {
            List<double> Tist = new List<double>();
            int index = 0;

            while (WalkN(context, index) != 1.0101)
            {
                Tist.Add(WalkN(context, index));
                index++;
            }

            var sortedList = from T in Tist orderby T select T;

            if (context.operatorToken.Type == ExcelApplicationLexer.MMAX)
            {
                Debug.WriteLine("MMAX(");
                for (index = 0; index < Tist.Count(); ++index)
                {
                    Debug.WriteLine("{0}", Tist.ElementAt(index));
                    if (index != Tist.Count() - 1)
                        Debug.WriteLine(",");
                }
                Debug.WriteLine(")");
                return sortedList.ElementAt(sortedList.Count() - 1);
            }
            else
            {
                Debug.WriteLine("MMIN(");
                for (index = 0; index < Tist.Count(); ++index)
                {
                    Debug.WriteLine("{0}", Tist.ElementAt(index));
                    if (index != Tist.Count() - 1)
                        Debug.WriteLine(",");
                }
                Debug.WriteLine(")");
                return sortedList.ElementAt(0);
            }

        }
        private double WalkLeft(ExcelApplicationParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <ExcelApplicationParser.ExpressionContext>(0));
        }
        private double WalkRight(ExcelApplicationParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <ExcelApplicationParser.ExpressionContext>(1));
        }
        private double WalkN(ExcelApplicationParser.ExpressionContext context, int index)
        {
            try
                {
                    return Visit(context.GetRuleContext <ExcelApplicationParser.ExpressionContext>(index));
                }
            catch (NullReferenceException) 
                { 
                    return 1.0101; 
                }
        }
    }
}
