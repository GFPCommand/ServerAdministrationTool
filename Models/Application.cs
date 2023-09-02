namespace Server_Administration_Tool.Models
{
    public class Application
	{
        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public int Size { get; set; }

        public string? Version { get; set; }

        public string Service { get; set; } = null!;

        public DateTime UploadDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public string? Description { get; set; }

        public string? Link { get; set; }
    }
}
