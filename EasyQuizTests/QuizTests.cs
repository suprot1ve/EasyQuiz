using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			quiz.AddNewTask(new CreatorMultipleChoiceTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			MultipleChoiceTask task = quiz.Tasks[0] as MultipleChoiceTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.IsFalse(task.SwapAnswer);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<Answer>));
		}

		[Test]
		public void TestAddMultipleResponseTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewTask(new CreatorMultipleResponseTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			MultipleResponseTask task = quiz.Tasks[0] as MultipleResponseTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.IsFalse(task.SwapAnswer);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<MultipleAnswer>));
		}

		[Test]
		public void TestAddShortAnswerTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewTask(new CreatorShortAnswerTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			ShortAnswerTask task = quiz.Tasks[0] as ShortAnswerTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<Answer>));
		}

		[Test]
		public void TestAddTrueFalseTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewTask(new CreatorTrueFalseTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			TrueFalseTask task = quiz.Tasks[0] as TrueFalseTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.IsFalse(task.SwapAnswer);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<TrueFalseAnswer>));
		}

		[Test]
		public void TestAddSequenceTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewTask(new CreatorSequenceTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			SequenceTask task = quiz.Tasks[0] as SequenceTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<SequenceAnswer>));
		}

		[Test]
		public void TestAddMatchingTask()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewTask(new CreatorMatchingTask());
			Assert.AreEqual(quiz.Tasks.Count, 1);
			MatchingTask task = quiz.Tasks[0] as MatchingTask;
			Assert.IsNotNull(task);
			Assert.AreEqual(task.Question, "Введите вопрос...");
			Assert.AreEqual(task.Point, 1);
			Assert.AreEqual(task.Answers.Count, 0);
			Assert.AreEqual(task.Answers.GetType(), typeof(ObservableCollection<MatchingAnswer>));
		}

		[Test]
		public void TestAddGradePoint()
		{
			Quiz quiz = new Quiz("MyQuiz");
			quiz.AddNewGradePoint();
			Assert.AreEqual(quiz.GradePoints.Count, 1);
			GradePoint gradePoint = quiz.GradePoints[0] as GradePoint;
			Assert.IsNotNull(gradePoint);
			Assert.AreEqual(gradePoint.Percent, 0);
			Assert.AreEqual(gradePoint.Point, 0);
		}
	}
}
