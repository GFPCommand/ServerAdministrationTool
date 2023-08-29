namespace Server_Administration_Tool.Models
{
	public class Application
	{
		public string Name { get; private set; }

        public string Path { get; private set; }

        public int Size { get; private set; }

        public string Version { get; private set; }

        public DateTime UploadDate { get; private set; }

        public DateTime LastUpdate { get; private set; }

        public string Description { get; private set; }
    }
}
