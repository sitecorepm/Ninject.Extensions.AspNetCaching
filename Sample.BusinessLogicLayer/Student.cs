using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain;
using Ninject.Extension.AspNetCache;

namespace Sample.BusinessLogicLayer
{
    [CacheAllVirtualMethods(DefaultTimeoutMinutes = 1)]
    public class Student
    {
        public Student() { }

        /// <summary>
        /// Call some data layer to retrieve the grades for this student/course combination.
        /// For demonstration purposes, this I'll just create a static result set
        /// </summary>
        public virtual IEnumerable<Grade> GetGrades(string studentid, string courseid)
        {
            System.Diagnostics.Debug.WriteLine("{0} - GetGrades data retrieved", DateTime.Now);

            var course = new Course() { CourseID = "mcs123", CourseName = "Math" };
            var results = new Grade[]{
                new Grade() { Course = course, Name = "Quiz 1", MaxScore = 100, Score = 90 },
                new Grade() { Course = course, Name = "Test 1", MaxScore = 100, Score = 100 },
                new Grade() { Course = course, Name = "Quiz 2", MaxScore = 100, Score = 67 },
                new Grade() { Course = course, Name = "Mid Term", MaxScore = 110, Score = 86 }
            };

            return results;
        }

        /// <summary>
        /// Call some data layer to retrieve the grades for this student/course combination.
        /// For demonstration purposes, this I'll just create a static result set
        /// </summary>
        [CacheTimeout(TimeoutMinutes = 2)]
        public virtual IEnumerable<Grade> GetGradesWithHigherCacheTimeout(string studentid, string courseid)
        {
            System.Diagnostics.Debug.WriteLine("{0} - GetGradesWithHigherCacheTimeout data retrieved", DateTime.Now);

            var course = new Course() { CourseID = "mcs123", CourseName = "Math" };
            var results = new Grade[]{
                new Grade() { Course = course, Name = "Quiz 1", MaxScore = 100, Score = 90 },
                new Grade() { Course = course, Name = "Test 1", MaxScore = 100, Score = 100 }
            };

            return results;
        }
    }
}
