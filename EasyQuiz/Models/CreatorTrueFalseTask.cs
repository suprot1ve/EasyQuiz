namespace EasyQuiz.Models
{
	public class CreatorTrueFalseTask : ICreatorTask
	{
		public ITestTask Create() => new TrueFalseTask();
	}
}
