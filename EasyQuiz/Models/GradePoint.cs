namespace EasyQuiz.Models
{
	public  class GradePoint
	{
		private int _percent;
		private int _point;

		public int Percent { get => _percent; set => _percent = value; }
		public int Point { get => _point; set => _point = value; }
	}
}