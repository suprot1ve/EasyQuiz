using EasyQuiz.Models;
using NUnit.Framework;

namespace EasyQuizTests
{
	class TasksTests
	{
		[SetUp]
		public void SetUp()
		{
			Quiz quiz = new Quiz("MyQuiz");
			CurrentQuiz.Data = quiz;
		}

		[Test]
		public void TestAddAnswer()
		{
			CurrentQuiz.Data.AddNewTask(new CreatorMultipleChoiceTask());
			CurrentQuiz.Data.Tasks[0].AddAnswer();
			MultipleChoiceTask task = CurrentQuiz.Data.Tasks[0] as MultipleChoiceTask;
			Assert.AreEqual(task.Answers[0].Value, "Ваш ответ...");
			Assert.AreEqual(task.Answers[0].GetType(), typeof(Answer));
		}

		[Test]
		public void TestAddTrueFalseAnswer()
		{
			CurrentQuiz.Data.AddNewTask(new CreatorMultipleResponseTask());
			CurrentQuiz.Data.Tasks[0].AddAnswer();
			MultipleResponseTask task = CurrentQuiz.Data.Tasks[0] as MultipleResponseTask;
			Assert.AreEqual(task.Answers[0].Value, "Ваш ответ...");
			Assert.AreEqual(task.Answers[0].GetType(), typeof(TrueFalseAnswer));
		}

		[Test]
		public void TestAddMatchingAnswer()
		{
			CurrentQuiz.Data.AddNewTask(new CreatorMatchingTask());
			CurrentQuiz.Data.Tasks[0].AddAnswer();
			MatchingTask task = CurrentQuiz.Data.Tasks[0] as MatchingTask;
			Assert.AreEqual(task.Answers[0].Value, "Ваш ответ...");
			Assert.AreEqual(task.Answers[0].GetType(), typeof(MatchingAnswer));
		}

		[Test]
		public void TestAddSequenceAnswer()
		{
			CurrentQuiz.Data.AddNewTask(new CreatorSequenceTask());
			CurrentQuiz.Data.Tasks[0].AddAnswer();
			SequenceTask task = CurrentQuiz.Data.Tasks[0] as SequenceTask;
			Assert.AreEqual(task.Answers[0].Value, "Ваш ответ...");
			Assert.AreEqual(task.Answers[0].GetType(), typeof(SequenceAnswer));
		}

	}
}
