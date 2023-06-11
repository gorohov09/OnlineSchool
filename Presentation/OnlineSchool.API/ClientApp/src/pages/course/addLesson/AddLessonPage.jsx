import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import useCourseService from "../../../services/CourseService";
import {Spinner} from "react-bootstrap";
import { ThemeProvider  } from '@mui/material/styles';
import theme from '../../../components/muiTheme.jsx';

import { useNavigate, useParams } from "react-router-dom";
import { useState } from "react";

import './addLessonPage.scss';

const AddLessonPage = ({setIsAuth}) => {

    const {moduleId} = useParams();
    const [name, setName] = useState();
    const [linkVideo, setLinkVideo] = useState();
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const {saveLesson} = useCourseService();

    const onHandleSubmit = async(e) => {
        e.preventDefault();

        if (name == null || name === '' || linkVideo == null || linkVideo === ''){
            return;
        }

        const data = await saveLesson({
			name,
            linkVideo
		}, moduleId).then(setLoading(loading => true));

		if (data?.status === 500){
			console.log('Очистка формы')
			e.target.reset(); 
		}
		else{
			navigate(-1);
		}
    }

    return (
        <>
        <Navbar setIsAuth={setIsAuth}/>
        <div className="lesson">
            <div className="left_side">
                <Sidebar />
            </div>
            <div className="right_side">
                <div className="lessonContainer">
                    <div className="addLesson">
                        {
                            !loading ?
                            <>
                                <div className="addLesson__form">
                                
                                <form onSubmit={onHandleSubmit} className="lesson__form"> 
                                    <h2>Добавление урока</h2>
                                    <div className="lesson_name input">
                                        <label>
                                            <p>Название</p>
                                            <input type="text" onChange={e => setName(e.target.value)}/>
                                        </label>
                                    </div>
                                    <div className="lesson_linkVideo input">
                                        <label>
                                            <p>Ссылка на видео YouTube</p>
                                            <input type="text" onChange={e => setLinkVideo(e.target.value)}/>
                                        </label>
                                    </div>
                                    <div className="button input">
                                        <ThemeProvider theme={theme}>
                                            <Button variant="contained" size="medium" type="submit">Добавить</Button>
                                        </ThemeProvider>
                                    </div>     
                                </form>
                               
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
        </div>
        </>
    )
}

export default AddLessonPage;