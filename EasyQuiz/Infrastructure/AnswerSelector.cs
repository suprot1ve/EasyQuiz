using System.Windows;
using System.Windows.Controls;

using EasyQuiz.Models;

namespace EasyQuiz.Infrastructure
{
	public class AnswerSelector : DataTemplateSelector
	{
		public DataTemplate Answer { get; set; }
		public DataTemplate MultipleAnswer { get; set; }
		public DataTemplate SequenceAnswer { get; set; }
		public DataTemplate MatchingAnswer { get; set; }
		public DataTemplate TrueFalseAnswer { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is SequenceAnswer)
				return SequenceAnswer;
			if (item is MatchingAnswer)
				return MatchingAnswer;
			if (item is MultipleAnswer)
				return MultipleAnswer;
			if (item is TrueFalseAnswer)
				return TrueFalseAnswer;
			if (item is Answer)
				return Answer;
			else
				return null;
		}
	}
}
