using System;
using Core.Enums;

namespace Core.Models;

public class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseNumber { get; set; }
    public string Title { get; set; }
    public CourseType CourseType { get; set; }
    public int Days { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public override string ToString()
    {
        return $"Kursnr.: {CourseNumber} Titel: {Title} Kurstyp: {CourseType} Längd: {Days} dagar Startdatum: {StartDate.ToShortDateString()} Slutdatum: {EndDate.ToShortDateString()}";
    }
}
