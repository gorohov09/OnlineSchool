import React, { useState, useEffect } from 'react';
import Nav from 'react-bootstrap/Nav';
import { NavLink, useNavigate } from 'react-router-dom';
import { Button, Container, Row } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
import Navbar from 'react-bootstrap/Navbar';
import CreateTeacher from '../../components/modal/CreateTeacher';
import ShowCourse from '../../components/modal/ShowCourse';
import useCourseService from '../../services/CourseService.jsx';
// import Navbar from '../../components/navbar/Navbar';
// import CreatePart from '../components/modals/CreatePart';
// import CreateType from '../components/modals/CreateType';

const HomeManager = ({setIsAuth}) => {
    const {getPopularCourses, registerUser} = useCourseService();
    const navigate = useNavigate();
    const [courses, setCourses] = useState(null);

    const [isTeacherVisible, setIsTeacherVisible] = useState(false);
    const [courseId, setCourseId] = useState('');
    const [isCourseInfoVisible, setIsCourseInfoVisible] = useState(false);
    const [isPartVisible, setIsPartVisible] = useState(false);

    useEffect(() => {
        getPopularCourses()
            .then(data => setCourses(data));
    }, []);

    const onHandleToCourse = (courseId) => {
        setIsCourseInfoVisible(true);
        setCourseId(courseId);

    }

    const renderCourses = () => {
        return(
            courses.map((course, index) => {
                return(
                    <Row 
                        key={course.courseId} 
                        style={{background: index % 2 === 0 ? '#ccc2f8' : 'transparent', padding: 10, fontWeight: 600, fontSize: '20px', cursor:'pointer' }}
                        onClick={() => onHandleToCourse(course.courseId)}
                        >
                        {course.name}| Количество студентов:  {course.countStudents}| Количество задач в курсе:  {course.countTasks} 
                    </Row>
                )
            })
        )
    }

    let items;
    if (courses != null){
        items = renderCourses();
    }

    return (
        <div 
            className='manager__container'
            style={{background:' linear-gradient(120deg, #dcd3ff, #ffffff, #cbbdff)', minHeight:'100vh'}}
            >
            <Navbar bg="dark" variant="ligth">
                <Container>
                <NavLink to={'/manager'} style={{color:'#ffffff', fontSize:'36px', fontWeight:'500', textDecoration:'none'}}>ПоШагам</NavLink>
                <span style={{fontSize:'25px'}}>MANAGER</span>
                <Button 
                    variant='outline-light'
                    size="lg"
                    style={{border:'none'}} 
                    className = 'ms-3' 
                    onClick={() => {
                        sessionStorage.clear();
                        setIsAuth(false);
                        navigate("/login");
                    }}
                >
                    Выйти
                </Button>

                </Container>
            </Navbar>
            <Container className='d-flex flex-column align-items-center'>
                <Container 
                style={{border:'1px solid #6439ff', borderRadius:'15px', background:'#dcd3ff'}}
                className='m-5'>
                    <Row className='d-flex flex-column m-3' style={{background:'#e4d6f8'}}>
                        <h3 style={{width:'50%'}}>Курсы в продаже</h3>
                        <hr/>
                        {
                            items
                        }
                        <hr/>
                    </Row>
                </Container>
                <Container className='d-flex flex-column align-items-center'>
                    <Button 
                        variant={'outline-light'} 
                        style={{color:'#6439ff', fontSize:'20px',borderColor:'#6439ff', background:'#ccc2f8'}}
                        className='mt-4 p-2 w-25'
                        onClick={() => setIsTeacherVisible(true)}
                        >
                        Добавить преподавателя
                    </Button>
                    {isCourseInfoVisible ?
                        <ShowCourse show={isCourseInfoVisible} onHide={()=>setIsCourseInfoVisible(false) } courseId={courseId}/>
                        :
                        null
                    }
                    <CreateTeacher show={isTeacherVisible} onHide={()=>setIsTeacherVisible(false)}/>
                    
                </Container>
                
            </Container>
        </div>
    );
};

export default HomeManager;