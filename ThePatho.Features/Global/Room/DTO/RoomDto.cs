namespace ThePatho.Features.Global.Room.DTO
{
    public class RoomDto
    {
        public string RoomCode { get; set; } = null!;
        public string RoomName { get; set; } = null!;
        public string BuildingCode { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class RoomItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RoomDto> RoomList { get; set; } = new();
    }
}
