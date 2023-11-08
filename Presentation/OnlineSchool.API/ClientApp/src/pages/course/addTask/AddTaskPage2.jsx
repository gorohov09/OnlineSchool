import { useNavigate, useParams } from "react-router-dom";
import { useState } from "react";
import * as React from 'react';

import Button from '@mui/material/Button';
import ButtonGroup from '@mui/material/ButtonGroup';

import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";

import { ThemeProvider  } from '@mui/material/styles';
import theme from '../../../components/muiTheme.jsx';

import useCourseService from "../../../services/CourseService";
import OneAnswer from "./oneAnswer/OneAnswer";
import FreeAnswer from "./freeAnswer/FreeAnswer";
import {Spinner} from "react-bootstrap";
import './addTaskPage.scss';



const AddTaskPage = ({setIsAuth}) => {

    const navigate = useNavigate();
    const {lessonId} = useParams();
    const [loading, setLoading] = useState(false);
    const [name, setName] = useState();
    const [type, setType] = useState('freeResponse');
    const [description, setDescription] = useState('');
    const [question, setQuestion] = useState('');
    const [answer, setAnswer] = useState('');
    const [answers, setAnswers] = useState(null);
    const [wrongAnswers, setWrongAnswers] = useState('');
    const [isFreeAnswer, setIsFreeAnswer] = useState(true);

    const {saveTask} = useCourseService();

    const onHandleSubmit = async(e) => {
        e.preventDefault();

        if (name == null || name === '' || description == null || description === ''||
        question == null || question === '' || answer == null || answer === ''){
            return;
        }

        if (type == 'oneAnswer' ){
            if( wrongAnswers == null || wrongAnswers === '')
            
            return;
        }

        let data = {
            name,
            type,
            description,
            question,
            answer,
            answers: null,
        };
        if (type == "oneAnswer") {
            data = {...data, wrongAnswers};
        } else {
            data = {...data, wrongAnswers:null};
        }
        

        console.log(data);
        console.log(lessonId);

        const res = await saveTask(data, lessonId)
            .then(setLoading(loading => true))
        
        if (res?.status === 500){
            console.log('Очистка формы')
            e.target.reset(); 
        }
        else{
            navigate(`/lessons/${lessonId}`)
        }
    }

    return(
        <>
        <Navbar setIsAuth={setIsAuth}/>
        <div className="task">
            <div className="left_side"><Sidebar/></div>
            <div className="right_side">
                <div className="task__container">
                    <div className="addTask">
                        <div className="addTask__form">
                            <form onSubmit={onHandleSubmit} className="task__form"> 
                                <h2>Добавление задания</h2>
                                <div className="task_name input">
                                    <label>
                                        <p>Название задания</p>
                                        <input type="text" onChange={e => setName(e.target.value)}/>
                                    </label>
                                </div>
                                <div className="lesson_description input">
                                    <label>
                                        <p>Описание задания</p>
                                        <input type="text" onChange={e => setDescription(e.target.value)}/>
                                    </label>
                                </div>
                                <div className="lesson_question input">
                                    <label>
                                        <p>Вопрос задания</p>
                                        <input type="text" onChange={e => setQuestion(e.target.value)}/>
                                    </label>
                                </div>

                                <ThemeProvider theme={theme}>
                                    <ButtonGroup variant="contained" size="large" aria-label="outlined button group">
                                        <Button disabled={isFreeAnswer} onClick={() => setIsFreeAnswer(true)}>Вопрос</Button>
                                        <Button disabled={!isFreeAnswer} onClick={() => setIsFreeAnswer(false)}>Выбор ответа</Button>
                                    </ButtonGroup>
                                </ThemeProvider>

                                {isFreeAnswer ? <FreeAnswer setAnswer={setAnswer} setType={setType}/> : <OneAnswer setAnswer={setAnswer} setWrongAnswers={setWrongAnswers} setType={setType}/>}
                                
                                <div className="button input">
                                    <ThemeProvider theme={theme}>
                                        <Button variant="contained" size="medium" type="submit">Добавить</Button>
                                    </ThemeProvider>
                                </div>     
                            </form>
                    </div>
                </div>
                    
                    
                </div>
            </div>
        </div>
        </>
    )
}

export default AddTaskPage;