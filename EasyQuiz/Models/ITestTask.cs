﻿namespace EasyQuiz.Models
{
	public  interface ITestTask
	{
		string Question { get; set; }
		int Point { get; set; }

		void AddAnswer();
		int GetResult();
	}
}