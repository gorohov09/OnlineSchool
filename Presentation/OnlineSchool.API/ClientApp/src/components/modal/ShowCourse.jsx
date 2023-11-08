import React, {useState, useEffect} from 'react';
import { Button, Container, Form } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
import useCourseService from '../../services/CourseService';

const ShowCourse = ({show, onHide, courseId}) => {
    const {getCourseById} = useCourseService();
    const [data, setData] = useState(null);

    useEffect(()=>{
        getCourseById(courseId)
            .then(data => setData(data));
    },[]);

    const renderCourseInfo = () => {
        return(
            <Container className='d-flex flex-column align-items-center' style={{color:'#6439ff'}}>
                <h2>{data.name}</h2>
                <h5>Дата создания: {data.create}</h5>
                <h5>Дата обновления: {data.update}</h5>
                <p></p>
                <p style={{fontSize:'20px'}}>Описание: {data.description}</p>
                <p></p>
                <h4>Модули</h4>
                {data.modules.map((module, index) => {
                    return(
                        <Container key={index} className='d-flex flex-column '>
                            <h4>Модуль: {module.name}</h4>
                            <hr/>
                            <h5> Уроки:</h5>
                            {module.lessons.map((lesson, index) => {
                                return(
                                    <Container key={index} className='d-flex flex-column '>
                                    <h5>{lesson.name}</h5>
                                </Container>
                                )
                                
                            })}
                            <hr/>
                        </Container>
                    )
                })}
            </Container>
        )
    }

    let courseInfo = [];
    if(data !== null){
        courseInfo = renderCourseInfo();
    }

    return (
        <Container>
            <Modal
                show={show}
                onHide={onHide}
                size="lg"
                centered
            >
                <Modal.Header closeButton
                    style={{background: '#ccc2f8' }}>
                    <Modal.Title id="contained-modal-title-vcenter" style={{color: '#6439ff'}}>
                    Добавить преподавателя
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body 
                    className='d-flex flex-column align-items-center'
                    style={{background: '#ccc2f8' }}>
                   {courseInfo}
                    
                </Modal.Body>
                {/* <Modal.Footer
                    style={{background: '#ccc2f8' }}>                    
                </Modal.Footer> */}
            </Modal>
        </Container>
    );
};

export default ShowCourse;