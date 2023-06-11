import Header from "../../components/header/Header";
import { useParams} from "react-router-dom";
import StudentRatingListByCourse from "../../components/studentRatingListByCourse/StudentRatingListByCourse";

import "./studentRatingByCoursePage.scss";

const StudentRatingByCoursePage = ({setIsAuth}) => {
    const {courseId} = useParams();

    return (
        <>
            <Header setIsAuth={setIsAuth}/>
            <div className="wrapper_student_rating_course">
                <h1>Рейтинг студентов курса</h1>
                <div className="student_rating_course">
                    <StudentRatingListByCourse courseId={courseId}/>
                </div>
            </div>
        </>
    )
}

export default StudentRatingByCoursePage;