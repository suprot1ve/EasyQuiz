using System;

using EasyQuiz.Models;
using NUnit.Framework;

namespace EasyQuizTests
{
	class QuizTests
	{
		[Test]
		public void TestCreateQuiz()
		{
			Quiz quiz = new Quiz("FirstQuiz");

			Assert.AreEqual(quiz.Name, "FirstQuiz");
			Assert.AreEqual(quiz.TimeLimit, TimeSpan.Zero);
			Assert.AreEqual(quiz.Tasks.Count, 0);
			Assert.AreEqual(quiz.GradePoints.Count, 0);
		}

		[Test]
		public void TestAddMultipleChoiceTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddTask(new CreatorMultipleChoiceTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			MultipleChoiceTask task = quiz.Tasks[0] as MultipleChoiceTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.IsFalse(task.SwapAnswer);
		}

		[Test]
		public void TestAddGradePoint()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddGradePoint();
			Assert.AreEqual(quiz.GradePoints.Count, 1);
			GradePoint gradePoint = quiz.GradePoints[0] as GradePoint;
			Assert.IsNotNull(gradePoint);
			Assert.AreEqual(gradePoint.Percent, 0);
			Assert.AreEqual(gradePoint.Point, 0);
		}
	}
}
