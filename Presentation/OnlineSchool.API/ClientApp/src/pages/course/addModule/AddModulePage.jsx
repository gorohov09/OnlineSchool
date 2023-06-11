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

import './addModulePage.scss';

const AddModulePage = ({setIsAuth}) => {

    const {courseId} = useParams();
    const [name, setName] = useState();
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const {saveModule} = useCourseService();

    // const saveModuleL = async () => {
    //     const title = document.querySelector('#title');

    //     if (title.value == null || title.value === ''){
    //         return;
    //     }
    //     const data = {
    //         name: title.value,
    //     }

    //     const res = await saveModule(data, courseId)
    //         .then(setLoading(loading => true))
        
    //     if (res)
    //         navigate(`/courses/${courseId}`)
    // }

    const onHandleSubmit = async(e) => {
        e.preventDefault();

        if (name == null || name === ''){
            return;
        }

        const data = await saveModule({
			name: name,
		}, courseId).then(setLoading(loading => true));

		if (data?.status === 500){
			console.log('Очистка формы')
			e.target.reset(); 
		}
		else{
			navigate(`/courses/${courseId}`)
		}
    }

    return (
        <>
        <Navbar setIsAuth={setIsAuth}/>
        <div className="module">
            <div className="left_side">
                <Sidebar />
            </div>
            <div className="right_side">
            <div className="moduleContainer">
                <div className="addModule">
                    {
                        !loading ?
                        <>
                            <div className="addModule__form">
                            <form onSubmit={onHandleSubmit} className="course__form"> 
                                <h2>Добавление модуля</h2>
                                <span>Введите название модуля</span>
                                <div className="module_name input">
                                    <label>
                                        <p>Название:</p>
                                        <input type="text" onChange={e => setName(e.target.value)}/>
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

export default AddModulePage;