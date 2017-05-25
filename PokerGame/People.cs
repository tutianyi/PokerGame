using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public class People : Player
    {
        private readonly Func<int> input;
        private readonly Action<string> output;

        public People(string name, Func<int> input, Action<string> output)
            : base(name)
        {
            this.input = input;
            this.output = output;
        }

        public override CardGroup Follow(CardGroup againstCard)
        {
            output(hint(CandidateShowCards(againstCard)));
            var select = input();
            var group = CandidateShowCards(againstCard)[select];
            ShowCard(group);
            return group;
        }

        private string hint(IDictionary<int, CardGroup> groups)
        {
            var builder = new StringBuilder();
            builder.Append("---");
            foreach(var group in groups)
            {
                builder.AppendFormat("{0}.{1}   ", group.Key, group.Value);
            }
            builder.Append("---");
            return builder.ToString();
        }
    }
}