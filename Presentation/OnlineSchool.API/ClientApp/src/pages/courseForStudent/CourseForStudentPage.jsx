import Header from "../../components/header/Header";
import StructureCourse from "../../components/structureCourse/StructureCourse";
import { useState, useEffect, useRef } from "react";
import { useParams, Link } from "react-router-dom";
import useCourseService from "../../services/CourseService";
import {Spinner} from "react-bootstrap";
import Button from '@mui/material/Button';

import "./courseForStudentPage.scss";

const CourseForStudentPage = ({setIsAuth}) => {
    const {courseId} = useParams();
    const [selectLessonId, setLessonId] = useState(null)
    const [dataLesson, setDataLesson] = useState(null);
    // const [description, setDescription] = useState();
    const [loading, setLoading] = useState(true);
    const isInitialMount = useRef(true);

    const {getLessonById, getFirstLessonByCourse} = useCourseService();

    useEffect(() => {
        if (isInitialMount.current) {
            isInitialMount.current = false;
        } else {
            getLessonById(selectLessonId)
            .then(data => setDataLesson(data))
            .then(setLoading(false));
        }
        
    }, [selectLessonId]);

    useEffect(() => {
        getFirstLessonByCourse(courseId)
            .then(data => setDataLesson(data))
            .then(setLoading(false));
    }, []);

    let idLesson, name, embedHtmlVideo, description;
    if (dataLesson != null){
        idLesson = dataLesson.id;
        name = dataLesson.name;
        embedHtmlVideo = dataLesson.embedHtmlVideo;
        console.log(dataLesson);
    }

    return (
        <>
            <Header setIsAuth={setIsAuth}/>
            <div className="wrapper_course">
                <div className="left_side">
                    <StructureCourse courseId={courseId} setLessonId={setLessonId}/>
                </div>
                <div className="right_side">
                    <div className="main_course">
                        {
                            !loading ?
                            <>
                                <div className="main_course__wrapper">
                                    <h2>{name}</h2>
                                    <p>{description}</p>
                                    <h3>Теоретическое видео:</h3>
                                    <div className="video" dangerouslySetInnerHTML={{ __html: embedHtmlVideo }} />
                                    <div className="tasksButton">
                                        <Button>
                                            <Link to={`/solveTasks/${idLesson}`}><span className="solveTask">Решать задания</span></Link>
                                        </Button>
                                    </div>
                                </div>
                            </>
                            :
                            <>
                                <Spinner style={{'color':'#6439ff'}}/>
                            </>
                        }
                    </div>
                </div>
                
                
            </div>
        </>
    )
}

export default CourseForStudentPage;