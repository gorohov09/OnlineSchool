import Game from '../../components/game/Game';
import Header from "../../components/header/Header";
import TasksList from '../../components/tasksList/TasksList';
import { useParams} from 'react-router-dom';
import { useState, useEffect, useRef } from 'react';
import useCourseService from '../../services/CourseService';
import {Spinner} from 'react-bootstrap';

import './solveTaskPage.scss';

const SolveTasksPage = ({setIsAuth}) => {

    const {lessonId} = useParams();

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [shuffledAnswers, setShuffledAnswers] = useState([]);
    const [taskId, setTaskId] = useState(null);
    const [render, setRender] = useState(false);
    const isFirstRun = useRef(true);

    const {getFirstTaskByLesson, getTaskById} = useCourseService();

    useEffect(() => {
        getFirstTaskByLesson(lessonId)
            .then(data => {
                setData(data);
                setTaskId(data.taskId);
                if(data.type === 'Один ответ') {setShuffledAnswers(shuffleAnswers(data.answer, data.wrongAnswers))} 
            })
            .then(setLoading(false))
    }, []);

    useEffect(() => {
        if (isFirstRun.current) {
            isFirstRun.current = false;
            return;
        }

        getTaskById(taskId)
            .then(data => {setData(data);
                if(data.type === 'Один ответ') {setShuffledAnswers(shuffleAnswers(data.answer, data.wrongAnswers))} })
            .then(setLoading(false));
        console.log(data);


    }, [taskId, render]);

    const shuffleAnswers = (answer, wrongAnswers) => {
        let temp = [answer, ...wrongAnswers];
        return temp.sort(() => Math.random() - 0.5);
    }


    return (
        <>
        <Header setIsAuth={setIsAuth}/>
        <div className="solveTasks_wrapper">
            <TasksList lessonId={lessonId} setTaskId={setTaskId} render={render} taskId={taskId}/>
            {
                data != null ?
                <>
                    <Game taskInform={data} answers={shuffledAnswers} render={render} setRender={setRender}/>
                </>
                :
                <>
                    <Spinner style={{'color':'#6439ff'}}/>
                </>
            }
        </div>
        </>
    )
}

export default SolveTasksPage;