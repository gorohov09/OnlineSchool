import CourseItem from "../courseItem/CourseItem";
import useCourseService from "../../services/CourseService";
import { Spinner } from "react-bootstrap";

import { useState, useEffect } from "react";

import "./coursesForStudentList.scss";

const CoursesForStudentList = () => {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [isEnrollReq, setIsEnrollReq] = useState(false);

    const {getPopularCourses} = useCourseService();

    useEffect(() => {
        getPopularCourses()
            .then(data => setData(data))
            .then(setLoading(false));
        
    }, []);

    useEffect(() => {
        getPopularCourses()
            .then(data => setData(data))
            .then(setLoading(false));
        setIsEnrollReq(false);
    }, [isEnrollReq]);

    const renderCourses = () => {
        return data.
            map(course => {
                return <CourseItem courseId={course.courseId} 
                name={course.name} 
                description={course.description} 
                countStudents={course.countStudents} 
                countTasks={course.countTasks} 
                isEnroll={course.isEnroll}
                isReqSuccess={isEnrollReq}
                setIsEnrollReq={setIsEnrollReq}/>
        })
    }

    let items;
    if (data != null){
        items = renderCourses();
    }

    return (
        <>
            {
                !loading ?
                <>
                    {items}
                </>
                :
                <>
                    <Spinner style={{'color':'#6439ff'}}/>
                </>
        }
        </>
        
    )
}

export default CoursesForStudentList;