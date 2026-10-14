using System;
using System.Data.Common;
using Core.Enums;

namespace Core.Models;

public class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public required CourseTypeEnum CourseType { get; set; }
    public required int Days { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    
    public override string ToString()
    {
        return $"Kursnr.: {CourseNumber} Titel: {Title} Kurstyp: {CourseType} Längd: {Days} dagar Startdatum: {StartDate.ToShortDateString()} Slutdatum: {EndDate.ToShortDateString()}";
    }
}
