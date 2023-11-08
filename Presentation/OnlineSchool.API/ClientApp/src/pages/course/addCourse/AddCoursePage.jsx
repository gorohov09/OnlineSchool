import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import * as React from 'react';
import Button from '@mui/material/Button';
import useCourseService from "../../../services/CourseService";
import {Spinner} from "react-bootstrap";

import { ThemeProvider  } from '@mui/material/styles';
import theme from '../../../components/muiTheme.jsx';

import { useNavigate } from "react-router-dom";
import { useState } from "react";

import './addCoursePage.scss';

const AddCoursePage = ({setIsAuth}) => {

    const [loading, setLoading] = useState(false);
    const [name, setName] = useState();
    const [desc, setDesc] = useState();
    const navigate = useNavigate();

    const {saveCourse} = useCourseService();

    const onHandleSubmit = async(e) => {
        e.preventDefault();

        if (name == null || name === '' || desc == null || desc === ''){
            return;
        }

        const data = await saveCourse({
			name: name,
		  	description: desc
		});
        console.log(data);
		if (data?.status === 500){
			console.log('Очистка формы')
			e.target.reset(); 
		}
		else{
			navigate("/courses")
		}
    }

    return (
        <>
        <Navbar setIsAuth={setIsAuth}/>
        <div className="course">
            <div className="left_side">
                <Sidebar />
            </div>
            <div className="right_side">
                <div className="courseContainer">
                    <div className="addCourse">
                        {
                            !loading ?
                            <div className="addCourse__form">
                                <h2>Добавление курса</h2>
                                <form onSubmit={onHandleSubmit} className="course__form"> 
                                    <div className="course_name input">
                                        <label>
                                            <p>Название</p>
                                            <input type="text" onChange={e => setName(e.target.value)}/>
                                        </label>
                                    </div>
                                    <div className="course_desc input">
                                        <label>
                                            <p>Описание</p>
                                            <input type="text" onChange={e => setDesc(e.target.value)}/>
                                        </label>
                                    </div>
                                    <div className="button input">
                                        <ThemeProvider theme={theme}>
                                            <Button variant="contained" size="medium" type="submit">Добавить</Button>
                                        </ThemeProvider>
                                    </div>     
                                </form>
                               
                            </div>
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

export default AddCoursePage;