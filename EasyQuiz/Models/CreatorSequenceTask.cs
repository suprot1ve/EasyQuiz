﻿namespace EasyQuiz.Models
{
	public class CreatorSequenceTask : ICreatorTask
	{
		public ITestTask Create() => new SequenceTask();
	}
}
