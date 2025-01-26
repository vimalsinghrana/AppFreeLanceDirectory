namespace AppFreeLanceDirectory
{
	public class Skillset
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int FreelancerId { get; set; }
		public User Freelancer { get; set; }
	}
}
