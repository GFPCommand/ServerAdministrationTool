namespace Server_Administration_Tool.Models
{
    [Serializable]
	public class Application
	{
		public string Name { get; set; }

        public string Path { get; set; }

        public int Size { get; set; }

        public string Version { get; set; }

        public string Service { get; set; }

        public DateTime UploadDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
