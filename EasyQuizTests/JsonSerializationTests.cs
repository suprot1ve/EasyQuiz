using EasyQuiz.Models;
using EasyQuiz.Infrastructure;
using NUnit.Framework;
using System;

namespace EasyQuizTests
{
	class JsonSerializationTests
	{
		[SetUp]
		public void SetUp()
		{
			CurrentQuiz.Data = new Quiz("newQuiz");

			CurrentQuiz.Data.AddNewGradePoint();
			CurrentQuiz.Data.AddNewGradePoint();

			Answer answer = new Answer();
			answer.Value = "Answer 1";
			

			SequenceAnswer sequenceAnswer = new SequenceAnswer();
			sequenceAnswer.SequenceNumber = 1;
			sequenceAnswer.Value = "Answer 2";

			MatchingAnswer matchingAnswer = new MatchingAnswer();
			matchingAnswer.Value = "Yet another";
			matchingAnswer.MatchingValue = "answer";

			TrueFalseAnswer trueFalseAnswer1 = new TrueFalseAnswer();
			TrueFalseAnswer trueFalseAnswer2 = new TrueFalseAnswer();
			trueFalseAnswer1.Value = "Ur animal";
			trueFalseAnswer2.Value = "Ur human";
			trueFalseAnswer1.IsTrue = false;
			trueFalseAnswer2.IsTrue = true;

			MultipleChoiceTask task = new MultipleChoiceTask();
			task.Question = "Question?";
			task.Point = 5;
			task.SwapAnswer = true;
			task.Answers.Add(answer);

			SequenceTask task2 = new SequenceTask();
			task2.Question = "Question?";
			task2.Point = 10;
			task2.Answers.Add(sequenceAnswer);

			MatchingTask task3 = new MatchingTask();
			task3.Question = "Question?";
			task3.Point = 15;
			task3.SwapAnswer = true;
			task3.Answers.Add(matchingAnswer);

			TrueFalseTask task4 = new TrueFalseTask();
			task4.Question = "Question?";
			task4.Point = 20;
			task4.SwapAnswer = false;
			task4.Answers.Add(trueFalseAnswer1);
			task4.Answers.Add(trueFalseAnswer2);

			CurrentQuiz.Data.Tasks.Add(task);
			CurrentQuiz.Data.Tasks.Add(task2);
			CurrentQuiz.Data.Tasks.Add(task3);
			CurrentQuiz.Data.Tasks.Add(task4);
		}

		[Test]
		public void TestJsonFileService()
		{
			IFileService fileService = new JsonFileService();
			fileService.Save(@"C:\Users\user\Desktop", CurrentQuiz.Data);
			Quiz savedQuiz = fileService.Open(@"C:\Users\user\Desktop" + "newQuiz.json");

			Assert.AreEqual(savedQuiz.Name, "newQuiz");
			Assert.AreEqual(savedQuiz.GradePoints.Count, 2);
			Assert.AreEqual(savedQuiz.Tasks.Count, 4);

			MultipleChoiceTask task = savedQuiz.Tasks[0] as MultipleChoiceTask;
			SequenceTask task2 = savedQuiz.Tasks[1] as SequenceTask;
			MatchingTask task3 = savedQuiz.Tasks[2] as MatchingTask;
			TrueFalseTask task4 = savedQuiz.Tasks[3] as TrueFalseTask;

			Assert.AreEqual(task.Question, "Question?");
			Assert.AreEqual(task.Point, 5);
			Assert.IsTrue(task.SwapAnswer);
			Assert.AreEqual(task.Answers.Count, 1);

			Assert.AreEqual(task2.Question, "Question?");
			Assert.AreEqual(task2.Point, 10);
			Assert.AreEqual(task2.Answers.Count, 1);

			Assert.AreEqual(task3.Question, "Question?");
			Assert.AreEqual(task3.Point, 15);
			Assert.IsTrue(task3.SwapAnswer);
			Assert.AreEqual(task3.Answers.Count, 1);

			Assert.AreEqual(task4.Question, "Question?");
			Assert.AreEqual(task4.Point, 20);
			Assert.IsFalse(task4.SwapAnswer);
			Assert.AreEqual(task4.Answers.Count, 2);

			Answer asnwer = task.Answers[0] as Answer;
			SequenceAnswer asnwer2 = task2.Answers[0] as SequenceAnswer;
			MatchingAnswer asnwer3 = task3.Answers[0] as MatchingAnswer;
			TrueFalseAnswer asnwer4 = task4.Answers[0] as TrueFalseAnswer;
			TrueFalseAnswer asnwer5 = task4.Answers[1] as TrueFalseAnswer;
		}
	}
}
