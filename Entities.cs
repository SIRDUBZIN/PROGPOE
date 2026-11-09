using System.ComponentModel.DataAnnotations;
namespace RaceDay.Api.Models;
public class RaceEvent {
 public int Id {get;set;} [Required,MaxLength(150)] public string Name {get;set;}="";
 [Required,MaxLength(1000)] public string Description {get;set;}="";
 public DateTime Date {get;set;} [Required,MaxLength(200)] public string Location {get;set;}="";
 public decimal Distance {get;set;} [Required,MaxLength(30)] public string EventType {get;set;}="Run";
 public string? BannerUrl {get;set;} [Required] public string OrganiserId {get;set;}="";
 public List<RaceCategory> Categories {get;set;}=[]; public List<RaceEnrollment> Enrollments {get;set;}=[];
}
public class RaceCategory { public int Id {get;set;} public int EventId {get;set;} public RaceEvent? Event {get;set;} [Required,MaxLength(100)] public string Name {get;set;}=""; public string? Description {get;set;} }
public class RaceEnrollment { public int Id {get;set;} [Required] public string ParticipantId {get;set;}=""; public int EventId {get;set;} public RaceEvent? Event {get;set;} public int CategoryId {get;set;} public DateTime CreatedAt {get;set;}=DateTime.UtcNow; public string Status {get;set;}="Confirmed"; public RaceCategory? Category {get;set;} public RaceResult? Result {get;set;} }
public class RaceResult { public int Id {get;set;} public int EnrollmentId {get;set;} public RaceEnrollment? Enrollment {get;set;} public TimeSpan? FinishTime {get;set;} public int? Position {get;set;} }
public record RegisterRequest(string Email,string Password,string FirstName,string LastName,string Role);
public record LoginRequest(string Email,string Password);
public record EventRequest(string Name,string Description,DateTime Date,string Location,decimal Distance,string EventType);
public record CategoryRequest(int EventId,string Name,string? Description);
public record EnrollRequest(int EventId,int CategoryId);
public record ResultRequest(int EnrollmentId,TimeSpan? FinishTime,int? Position);
