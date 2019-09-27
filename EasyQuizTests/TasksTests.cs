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
			CurrentQuiz.Data.AddTask(new CreatorMultipleChoiceTask());
			CurrentQuiz.Data.Tasks[0].AddAnswer();
			MultipleChoiceTask task = CurrentQuiz.Data.Tasks[0] as MultipleChoiceTask;
			Assert.AreEqual(task.Answers[0].Value, "Ваш ответ...");
		}

	}
}
