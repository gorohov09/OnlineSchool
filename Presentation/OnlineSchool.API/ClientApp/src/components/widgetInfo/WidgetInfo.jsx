import "./widgetinfo.scss";

import {useState, useEffect} from 'react';
import PeopleIcon from '@mui/icons-material/People';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import useCourseService from "../../services/CourseService";

const WidgetInfo = ({type}) => {

    const{getTeacherStudentsCount, getTeacherCoursesCount, getCoursesCount, getStudentsCount} = useCourseService();

    const [countTeacherStudents, setCountTeacherStudents] = useState(0);
    const [countStudents, setCountStudents] = useState(0);
    const [countTeacherCourses, setCountTeacherCourses] = useState(0);
    const [countCourses, setCountCourses] = useState(0);
    useEffect(() => {
        getTeacherStudentsCount().
            then(data => setCountTeacherStudents(data));
        getTeacherCoursesCount().
            then(data => setCountTeacherCourses(data));
        getCoursesCount().
            then(data => setCountCourses(data));
        getStudentsCount().
            then(data => setCountStudents(data));
    }, []);
    let data;
    switch (type) {
        case "students":
            data = {
                title: "Кол-во ваших учеников",
                link: "Посмотреть всех",
                icon: <PeopleIcon className="icon"/>,
                counter: countTeacherStudents,
                allCount: countStudents
            };
            break;
        case "courses":
            data = {
                title: "Кол-во созданных вами курсов",
                link: "Посмотреть все",
                icon: <MenuBookIcon className="icon"/>,
                counter: countTeacherCourses,
                allCount: countCourses
            }
            break;

        default:
            break;  
    }

    const {title, link, icon, counter, allCount} = data;

    return (
        <div className="widget">
            <div className="left">
                <span className="title">{title}</span>
                <span className="counter">{counter}</span>
                <span className="link">{link}</span>
            </div>
            <div className="right">
                <div className="percentage">
                    <span className="title">От общего числа: {Math.round((counter/allCount)*100)}%</span>
                </div>
                {icon}
            </div>
        </div>
    )
}

export default WidgetInfo;