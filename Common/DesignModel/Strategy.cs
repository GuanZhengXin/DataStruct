using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DesignModel
{
    public interface IStrategy
    {
        void Process();
    }

    public class OneStrategy : IStrategy
    {
        public OneStrategy()
        {
        }

        public void Process()
        {
            Console.WriteLine("OneStrategy OneStrategy");
        }
    }

    public class TwoStrategy : IStrategy
    {
        public TwoStrategy()
        {
        }

        public void Process()
        {
            Console.WriteLine("TwoStrategy TwoStrategy");
        }
    }

    public class StrategyContext
    {
        private string _type;
        private IStrategy _strategy;
        public StrategyContext(string type, IStrategy strategy)
        {
            _type = type;
            _strategy = strategy;
        }

        public IStrategy GetStrategy()
        {
            return _strategy;
        }

        public bool IsHasType(string type)
        {
            return _type == type;
        }
    }

    public static class ShareStrategy
    {
        private static List<StrategyContext> algs = new List<StrategyContext>
        {
            new StrategyContext("1", new OneStrategy()),
             new StrategyContext("2", new TwoStrategy())
        };

        public static void ShareOptions(string type)
        {
            IStrategy dealStrategy = null;
            foreach (var deal in algs)
            {
                if (deal.IsHasType(type))
                {
                    dealStrategy = deal.GetStrategy();
                    break;
                }
            }
            dealStrategy.Process();
        }
    }
}
